CREATE TABLE [dbo].[ReportingEngine_Parameter]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ParameterName] VARCHAR(50) NULL, 
    [ParameterVariable] VARCHAR(50) NULL, 
    [ParameterLabel] VARCHAR(50) NULL, 
    [DisplayType] VARCHAR(50) NULL, 
    [FormatType] VARCHAR(50) NULL, 
    [ParameterDefault] VARCHAR(50) NULL, 
    [ParameterSql] NVARCHAR(MAX) NULL
)
