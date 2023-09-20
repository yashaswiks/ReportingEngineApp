using Dapper;
using Microsoft.Extensions.Configuration;
using ReportingEngineLibrary.Repository.IRepository;
using ReportingEngineLibrary.TableModels;
using System.Data;
using System.Data.SqlClient;

namespace ReportingEngineLibrary.Repository;

public class ReportingEngineParameterRepository : IReportingEngineParameterRepository
{
    private readonly IConfiguration _config;

    public ReportingEngineParameterRepository(IConfiguration config)
    {
        _config = config;
    }

    public async Task<ReportingEngineParameter> GetById(int? parameterId)
    {
        if (parameterId is null) return null;

        var param = new { Id = parameterId };
        var sql = @"SELECT p.* FROM ReportingEngine_Parameter p WHERE p.Id = @Id; ";

        using IDbConnection _db = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        var details = await _db.QueryFirstOrDefaultAsync<ReportingEngineParameter>(sql, param);

        return details;
    }

    public async Task<List<string>> GetReportSelectOptions(int? parameterId)
    {
        if (parameterId is null) return null;

        var parameterDetails = await GetById(parameterId);

        if (parameterDetails is null) return null;

        var paramSql = parameterDetails.ParameterSql;

        using IDbConnection _db = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        var details = await _db.QueryAsync<string>(paramSql);

        return details?.ToList();
    }
}