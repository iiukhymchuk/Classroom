CREATE TABLE dbo.Tasks
  (
  Id uniqueidentifier NOT NULL,
  [Name] nvarchar(255) NOT NULL,
  [Description] nvarchar(MAX) NULL,
  Modified datetime2(7) NOT NULL,
  Created datetime2(7) NOT NULL,
  CourseId uniqueidentifier NOT NULL
  )

ALTER TABLE dbo.Tasks ADD CONSTRAINT
  DF_Tasks_Id DEFAULT NEWID() FOR Id

ALTER TABLE dbo.Tasks ADD CONSTRAINT
  PK_Tasks_Id PRIMARY KEY CLUSTERED (Id)

ALTER TABLE dbo.Tasks ADD CONSTRAINT
  FK_Tasks_CourseId FOREIGN KEY (CourseId)
    REFERENCES dbo.Courses (Id)
    ON UPDATE CASCADE
    ON DELETE CASCADE