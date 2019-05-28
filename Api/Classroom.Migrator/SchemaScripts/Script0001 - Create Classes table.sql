CREATE TABLE dbo.Classes
  (
  Id uniqueidentifier NOT NULL,
  [Name] nvarchar(255) NOT NULL,
  [Description] nvarchar(MAX) NULL,
  ModifiedUTC datetime2(7) NOT NULL,
  CreatedUTC datetime2(7) NOT NULL
  )

ALTER TABLE dbo.Classes ADD CONSTRAINT
  DF_Classes_Id DEFAULT NEWID() FOR Id

ALTER TABLE dbo.Classes ADD CONSTRAINT
  PK_Classes_Id PRIMARY KEY CLUSTERED (Id)