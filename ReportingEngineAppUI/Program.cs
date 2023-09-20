using ReportingEngineAppUI.Data;
using ReportingEngineLibrary.Data;
using ReportingEngineLibrary.Repository;
using ReportingEngineLibrary.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddScoped<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddScoped<IReportEngineReportParameterMappingRepository, ReportEngineReportParameterMappingRepository>();
builder.Services.AddScoped<IReportingEngineReportsRepository, ReportingEngineReportsRepository>();
builder.Services.AddScoped<IReportingEngineParameterRepository, ReportingEngineParameterRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();