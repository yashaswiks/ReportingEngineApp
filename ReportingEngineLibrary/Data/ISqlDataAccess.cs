using ReportingEngineLibrary.Models;

namespace ReportingEngineLibrary.Data
{
    public interface ISqlDataAccess
    {
        Task InsertCustomerDetails(InsertCustomerDetailsModel customerDetails, string connectionString = "DefaultConnection");
    }
}