using ReportingEngineLibrary.Models;

namespace ReportingEngineLibrary.Repository.IRepository;

public interface IReportEngineReportParameterMappingRepository
{
    Task<List<FullReportEngineReportParameterMappingModel>?> GetReportParametersByReportIdAsync(int? reportId);
}