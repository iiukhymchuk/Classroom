INSERT INTO [dbo].[Courses]
    ([Id]
    ,[Name]
    ,[Description]
    ,[Modified]
    ,[Created])
VALUES
    (NEWID()
    , N'Курс для компонентів програмної інженерії 1'
    , N'Вот таке вот завдання'
    ,GETUTCDATE()
    ,GETUTCDATE()
    ),

    (NEWID()
    , N'Курс для компонентів програмної інженерії 2'
    , N'Вот таке вот завдання'
    ,GETUTCDATE()
    ,GETUTCDATE()
    ),

    (NEWID()
    , N'Курс для компонентів програмної інженерії 3'
    , N'Вот таке вот завдання'
    ,GETUTCDATE()
    ,GETUTCDATE()
    );

INSERT INTO [dbo].[ClassesCourses]
    ([ClassId]
    ,[CourseId]
    ,[Modified]
    ,[Created])
VALUES
    (
    (SELECT Id FROM [dbo].[Classes] WHERE [Name] = N'Компоненти програмної інженерії')
    ,(SELECT Id FROM [dbo].[Courses] WHERE [Name] = N'Курс для компонентів програмної інженерії 1')
    ,GETUTCDATE()
    ,GETUTCDATE()
    ),

    ((SELECT Id FROM [dbo].[Classes] WHERE [Name] = N'Компоненти програмної інженерії')
    ,(SELECT Id FROM [dbo].[Courses] WHERE [Name] = N'Курс для компонентів програмної інженерії 2')
    ,GETUTCDATE()
    ,GETUTCDATE()
    ),

    ((SELECT Id FROM [dbo].[Classes] WHERE [Name] = N'Компоненти програмної інженерії')
    ,(SELECT Id FROM [dbo].[Courses] WHERE [Name] = N'Курс для компонентів програмної інженерії 3')
    ,GETUTCDATE()
    ,GETUTCDATE()
    );

    INSERT INTO [dbo].[Courses]
    ([Id]
    ,[Name]
    ,[Description]
    ,[Modified]
    ,[Created])
VALUES
    (NEWID()
    , N'Курс для СМіТРПЗ-3 1'
    , N'Вот таке вот завдання'
    ,GETUTCDATE()
    ,GETUTCDATE()
    ),

    (NEWID()
    , N'Курс для СМіТРПЗ-3 2'
    , N'Вот таке вот завдання'
    ,GETUTCDATE()
    ,GETUTCDATE()
    ),

    (NEWID()
    , N'Курс для СМіТРПЗ-3 3'
    , N'Вот таке вот завдання'
    ,GETUTCDATE()
    ,GETUTCDATE()
    );

INSERT INTO [dbo].[ClassesCourses]
    ([ClassId]
    ,[CourseId]
    ,[Modified]
    ,[Created])
VALUES
    (
    (SELECT Id FROM [dbo].[Classes] WHERE [Name] = N'СМіТРПЗ-3')
    ,(SELECT Id FROM [dbo].[Courses] WHERE [Name] = N'Курс для СМіТРПЗ-3 1')
    ,GETUTCDATE()
    ,GETUTCDATE()
    ),

    ((SELECT Id FROM [dbo].[Classes] WHERE [Name] = N'СМіТРПЗ-3')
    ,(SELECT Id FROM [dbo].[Courses] WHERE [Name] = N'Курс для СМіТРПЗ-3 2')
    ,GETUTCDATE()
    ,GETUTCDATE()
    ),

    ((SELECT Id FROM [dbo].[Classes] WHERE [Name] = N'СМіТРПЗ-3')
    ,(SELECT Id FROM [dbo].[Courses] WHERE [Name] = N'Курс для СМіТРПЗ-3 3')
    ,GETUTCDATE()
    ,GETUTCDATE()
    );