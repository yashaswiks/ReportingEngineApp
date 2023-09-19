CREATE TABLE [dbo].[ReportEngine_ReportParameterMapping]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ReportId] INT NULL, 
    [ParameterId] INT NULL, 
    CONSTRAINT [FK_ReportEngine_ReportParameterMapping_ToReportEngine_Reports] FOREIGN KEY ([ReportId]) REFERENCES [ReportingEngine_Reports]([Id]), 
    CONSTRAINT [FK_ReportEngine_ReportParameterMapping_ToReportEngine_Parameters] FOREIGN KEY ([ParameterId]) REFERENCES [ReportingEngine_Parameter]([Id]) 
)
