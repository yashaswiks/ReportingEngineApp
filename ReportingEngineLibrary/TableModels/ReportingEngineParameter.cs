namespace ReportingEngineLibrary.TableModels;

public class ReportingEngineParameter
{
    public int Id { get; set; }
    public string? ParameterName { get; set; }
    public string? ParameterVariable { get; set; }
    public string? ParameterLabel { get; set; }
    public string? DisplayType { get; set; }
    public string? FormatType { get; set; }
    public string? ParameterDefault { get; set; }
    public string? ParameterSql { get; set; }
}