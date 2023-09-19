namespace ReportingEngineLibrary.TableModels;

public class ReportingEngineReports
{
    public int Id { get; set; }
    public string? ReportName { get; set; }
    public string? ReportCategory { get; set; }
    public string? ReportSql { get; set; }
    public string? Description { get; set; }
}