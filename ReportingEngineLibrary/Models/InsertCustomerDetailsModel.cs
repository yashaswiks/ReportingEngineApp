namespace ReportingEngineLibrary.Models;

public class InsertCustomerDetailsModel
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? Address { get; set; }
    public string? ZipCode { get; set; }
    public string? State { get; set; }
}