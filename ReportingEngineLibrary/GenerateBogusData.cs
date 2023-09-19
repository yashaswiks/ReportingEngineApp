using Bogus;
using ReportingEngineLibrary.Models;

namespace ReportingEngineLibrary;

public class GenerateBogusData
{
    public List<InsertCustomerDetailsModel> GetBogusData(int noOfRecords)
    {
        var fakerData = new Faker<InsertCustomerDetailsModel>()
            .RuleFor(c => c.FirstName, f => f.Name.FirstName())
            .RuleFor(c => c.LastName, f => f.Name.LastName())
            .RuleFor(c => c.DateOfBirth, f => f.Date.Past(75))
            .RuleFor(c => c.Address, f => f.Address.StreetAddress())
            .RuleFor(c => c.ZipCode, f => f.Address.ZipCode())
            .RuleFor(c => c.State, f => f.Address.StateAbbr());

        var customers = fakerData.Generate(noOfRecords);
        return customers;
    }
}