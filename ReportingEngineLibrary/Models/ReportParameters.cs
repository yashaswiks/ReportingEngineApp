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
}

public static class ParameterFormatType
{
    public const string Date_Type = "date";
}
