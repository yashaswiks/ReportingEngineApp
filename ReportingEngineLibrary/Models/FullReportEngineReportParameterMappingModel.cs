using ReportingEngineLibrary.TableModels;

namespace ReportingEngineLibrary.Models;

public class FullReportEngineReportParameterMappingModel : ReportEngineReportParameterMapping
{
    public ReportingEngineParameter? Parameter { get; set; }
    public ReportingEngineReports? Report { get; set; }
}