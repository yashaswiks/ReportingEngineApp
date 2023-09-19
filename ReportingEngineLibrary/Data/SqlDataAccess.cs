using Dapper;
using Microsoft.Extensions.Configuration;
using ReportingEngineLibrary.Models;
using System.Data;
using System.Data.SqlClient;

namespace ReportingEngineLibrary.Data;

public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration _config;

    public SqlDataAccess(IConfiguration configuration)
    {
        _config = configuration;
    }

    public async Task InsertCustomerDetails(InsertCustomerDetailsModel customerDetails,
        string connectionString = "DefaultConnection")
    {
        using IDbConnection _db = new SqlConnection(_config.GetConnectionString(connectionString));
        await _db.ExecuteAsync("dbo.sp_InsertCustomerDetails",
            param: customerDetails,
            commandType: CommandType.StoredProcedure);

    }
}