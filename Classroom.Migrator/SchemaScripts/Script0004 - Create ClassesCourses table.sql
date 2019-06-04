CREATE TABLE dbo.ClassesCourses
  (
  ClassId uniqueidentifier NOT NULL,
  CourseId uniqueidentifier NOT NULL,
  Modified datetime2(7) NOT NULL,
  Created datetime2(7) NOT NULL
  )

ALTER TABLE dbo.ClassesCourses ADD CONSTRAINT
  PK_ClassesCourses_Id PRIMARY KEY CLUSTERED (ClassId, CourseId)

ALTER TABLE dbo.ClassesCourses ADD CONSTRAINT
  FK_ClassesCourses_ClassesId FOREIGN KEY (ClassId)
    REFERENCES dbo.Classes (Id)
    ON UPDATE CASCADE
    ON DELETE CASCADE

ALTER TABLE dbo.ClassesCourses ADD CONSTRAINT
  FK_ClassesCourses_CoursesId FOREIGN KEY (CourseId)
    REFERENCES dbo.Courses (Id)
      ON UPDATE CASCADE
      ON DELETE CASCADE