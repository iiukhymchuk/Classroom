INSERT INTO [dbo].[Classes]
    ([Id]
    ,[Name]
    ,[Description]
    ,[Modified]
    ,[Created])
VALUES
    (NEWID()
    ,N'Computer Science class'
    ,N'It is something about the computers'
    ,GETUTCDATE()
    ,GETUTCDATE()),

	(NEWID()
    ,N'Computer Science class 2'
    ,N'It is something about the computers even more complex'
    ,GETUTCDATE()
    ,GETUTCDATE()),

	(NEWID()
    ,N'Fine Arts'
    ,N'Learning a visual art considered to have been created primarily for aesthetic and intellectual purposes and judged for its beauty and meaningfulness, specifically, painting, sculpture, drawing, watercolor, graphics, and architecture.'
    ,GETUTCDATE()
    ,GETUTCDATE())