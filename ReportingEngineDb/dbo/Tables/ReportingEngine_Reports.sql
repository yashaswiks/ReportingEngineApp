CREATE TABLE [dbo].[ReportingEngine_Reports]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ReportName] NVARCHAR(100) NULL, 
    [ReportCategory] VARCHAR(50) NULL, 
    [ReportSql] NVARCHAR(MAX) NULL, 
    [Description] NVARCHAR(MAX) NULL
)
