using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportingEngineLibrary.Models;

public class ReportParameters
{
    public int ReportId { get; set; }
    public string? DataType { get; set; }
    public string? ParameterName { get; set; }
    public string? ParameterVariable { get; set; }
    public string? ParameterLabel { get; set; }
    public string? ParameterValue { get; set; }
    public string? DisplayType { get; set; }
    public List<string> SelectOptions { get; set; } = new();
}

public static class ParameterFormatType
{
    public const string Date_Type = "date";
    public const string String_Type = "string";
    public const string Number_Type = "number";
    public const string Select_Type = "select";
}
