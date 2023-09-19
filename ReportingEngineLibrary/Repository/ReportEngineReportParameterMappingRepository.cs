using Dapper;
using Microsoft.Extensions.Configuration;
using ReportingEngineLibrary.Models;
using ReportingEngineLibrary.Repository.IRepository;
using ReportingEngineLibrary.TableModels;
using System.Data;
using System.Data.SqlClient;

namespace ReportingEngineLibrary.Repository;

public class ReportEngineReportParameterMappingRepository : IReportEngineReportParameterMappingRepository
{
    private readonly IConfiguration _configuration;

    public ReportEngineReportParameterMappingRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<List<FullReportEngineReportParameterMappingModel>?> GetReportParametersByReportIdAsync(
        int? reportId)
    {
        if (reportId is null) return null;
        using IDbConnection _db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

        var param = new { ReportId = reportId };

        var sql = @"SELECT
                        re.*, p.*, r.*
                        FROM ReportEngine_ReportParameterMapping re
                        LEFT JOIN ReportingEngine_Parameter p ON re.ParameterId = p.Id
                        LEFT JOIN ReportingEngine_Reports r ON re.ReportId = r.Id
                        WHERE re.ReportId = @ReportId; ";
        var reportParameters = await _db.QueryAsync<FullReportEngineReportParameterMappingModel,
            ReportingEngineParameter, ReportingEngineReports,
            FullReportEngineReportParameterMappingModel>(sql, (paramMapping, param, reports) =>
            {
                paramMapping.Parameter = param;
                paramMapping.Report = reports;

                return paramMapping;
            }, param);

        return reportParameters?.ToList();
    }
}