using ReportingEngineLibrary.Models;
using ReportingEngineLibrary.TableModels;

namespace ReportingEngineLibrary.Repository.IRepository;

public interface IReportingEngineReportsRepository
{
    Task<ReportingEngineReports?> GetByReportId(int? reportId);

    Task<List<ReportingEngineReports>?> GetAllAsync();

    Task<string> Test(int? reportId, List<ReportParameters> reportParameters);
}