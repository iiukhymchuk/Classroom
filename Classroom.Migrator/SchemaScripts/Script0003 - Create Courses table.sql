﻿CREATE TABLE dbo.Courses
  (
  Id uniqueidentifier NOT NULL,
  [Name] nvarchar(255) NOT NULL,
  [Description] nvarchar(MAX) NULL,
  Modified datetime2(7) NOT NULL,
  Created datetime2(7) NOT NULL
  )

ALTER TABLE dbo.Courses ADD CONSTRAINT
  DF_Courses_Id DEFAULT NEWID() FOR Id

ALTER TABLE dbo.Courses ADD CONSTRAINT
  PK_Courses_Id PRIMARY KEY CLUSTERED (Id)