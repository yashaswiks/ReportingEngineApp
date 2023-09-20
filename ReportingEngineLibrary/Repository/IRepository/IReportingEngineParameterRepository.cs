using ReportingEngineLibrary.TableModels;

namespace ReportingEngineLibrary.Repository.IRepository;

public interface IReportingEngineParameterRepository
{
    Task<List<string>> GetReportSelectOptions(int? parameterId);

    Task<ReportingEngineParameter> GetById(int? parameterId);
}