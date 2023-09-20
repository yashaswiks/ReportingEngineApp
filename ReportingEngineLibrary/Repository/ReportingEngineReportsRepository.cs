using CsvHelper;
using Dapper;
using Microsoft.Extensions.Configuration;
using ReportingEngineLibrary.Models;
using ReportingEngineLibrary.Repository.IRepository;
using ReportingEngineLibrary.TableModels;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace ReportingEngineLibrary.Repository;

public class ReportingEngineReportsRepository : IReportingEngineReportsRepository
{
    private readonly IConfiguration _configuration;

    public ReportingEngineReportsRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<List<ReportingEngineReports>?> GetAllAsync()
    {
        using IDbConnection _db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

        var sql = @"SELECT r.* FROM ReportingEngine_Reports r; ";

        var details = await _db.QueryAsync<ReportingEngineReports>(sql);

        return details?.ToList();
    }

    public async Task<ReportingEngineReports?> GetByReportId(int? reportId)
    {
        if (reportId is null) return null;
        using IDbConnection _db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

        var param = new { Id = reportId };
        var sql = @"SELECT r.* FROM ReportingEngine_Reports r WHERE r.Id = @Id; ";

        var details = await _db.QueryFirstOrDefaultAsync<ReportingEngineReports>(sql, param);

        return details;
    }

    public async Task<string> Test(int? reportId, List<ReportParameters> reportParameters)
    {
        var reportDetails = await GetByReportId(reportId);
        if (reportDetails is null) return null;

        var sql = reportDetails.ReportSql;
        if (sql is null) return null;

        var param = new DynamicParameters();
        if(reportParameters?.Count > 0)
        {
            foreach (var parameter in reportParameters!)
            {
                if (parameter.DataType == ParameterFormatType.Date_Type)
                    param.Add(parameter.ParameterVariable, DateTime.Parse(parameter.ParameterValue));
                else
                    param.Add(parameter.ParameterVariable, parameter.ParameterValue);
            }
        }


        using IDbConnection _db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

        var details = await _db.QueryAsync(sql, param);
        var csvString = SerializeDynamicToCsv(details);
        return csvString;
    }

    public string? SerializeDynamicToCsv(IEnumerable<dynamic> dynamicList)
    {
        if (dynamicList?.Count() == 0) return null;
        var csvDataList = new List<CsvData>();
        foreach (var dynamicResult in dynamicList)
        {
            var csvData = new CsvData
            {
                Data = new Dictionary<string, object>()
            };

            foreach (var property in dynamicResult)
            {
                var propertyName = Convert.ToString(property.Key, CultureInfo.InvariantCulture);
                csvData.Data[propertyName] = property.Value;
            }

            csvDataList.Add(csvData);
        }

        if (csvDataList.Count == 0) return null;

        using var writer = new StringWriter();
        using var csvWriter = new CsvWriter(writer,
            CultureInfo.InvariantCulture,
            true);

        var headings = csvDataList.First().Data.Keys.ToList();

        foreach (var heading in headings)
        {
            csvWriter.WriteField(heading);
        }

        csvWriter.NextRecord();

        foreach (var data in csvDataList)
        {
            foreach (var value in data.Data.Values)
            {
                csvWriter.WriteField(value);
            }

            csvWriter.NextRecord();
        }

        string csv = writer.ToString();
        return csv;
    }
}