INSERT INTO [dbo].[Courses]
    ([Id]
    ,[Name]
    ,[Description]
    ,[Modified]
    ,[Created])
VALUES
    (NEWID()
    , N'Компоненти програмної інженерії'
    , N'Компоненти програмної інженерії - один з найкращих предметів на якому модна отримати знання з основ створення та підтримки програм.
Основні питання:
1.  Принципи моделі S.O.L.I.D.
2.  Принцип відкритості закритості
3.  Призначення шаблону Repository
4.  Відмінність між шаблоном Repository та UnitOfWork
5.  Принцип сегрегації інтерфейсів
6.  Що таке SOAP сервіси? В якому вигляді передаються дані в SOAP сервіси.
7.  Статусні коди HTTP протоколу.
8.  Що таке REST Api
9.  Відмінність REST-Api від SOAP-Api
10.  Призначення WSDL файлу в протоколі SOAP
11.  Що таке сервісна шина даних, які проблеми при між компонентній взаємодії вона вирішує?
12.  Принципи роботи шаблону MVVM?
13.  Для чого потрібні стандартні інтерфейси INotifyPropertyChanged та INotifyCollectionChanged?
14.  DataBinding в WPF, які є типи біндінгу, що таке Binding.Converter
15.  Багаторівнева архітектура додатків.
16.  Придумайте дві можливі реалізації архітектури взаємодії мобільного додатку з сервером.
17.  Що таке мікро-сервіси, де вони використовуються?
18.  Поняття зв’язаності модулів.'
    ,GETUTCDATE()
    ,GETUTCDATE()
    ),

    (NEWID()
    , N'Introduction to Computer Science and Programming'
    , N'This subject is aimed at students with little or no programming experience. It aims to provide students with an understanding of the role computation can play in solving problems. It also aims to help students, regardless of their major, to feel justifiably confident of their ability to write small programs that allow them to accomplish useful goals. The class will use the Python™ programming language.'
    ,GETUTCDATE()
    ,GETUTCDATE()
    ),

    (NEWID()
    , N'Introduction to Algorithms'
    , N'This course provides an introduction to mathematical modeling of computational problems. It covers the common algorithms, algorithmic paradigms, and data structures used to solve these problems. The course emphasizes the relationship between algorithms and programming, and introduces basic performance measures and analysis techniques for these problems.'
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
    (SELECT Id FROM [dbo].[Classes] WHERE [Name] = N'Computer Science class')
    ,(SELECT Id FROM [dbo].[Courses] WHERE [Name] = N'Компоненти програмної інженерії')
    ,GETUTCDATE()
    ,GETUTCDATE()
    ),

    ((SELECT Id FROM [dbo].[Classes] WHERE [Name] = N'Computer Science class')
    ,(SELECT Id FROM [dbo].[Courses] WHERE [Name] = N'Introduction to Computer Science and Programming')
    ,GETUTCDATE()
    ,GETUTCDATE()
    ),

    ((SELECT Id FROM [dbo].[Classes] WHERE [Name] = N'Computer Science class')
    ,(SELECT Id FROM [dbo].[Courses] WHERE [Name] = N'Introduction to Algorithms')
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
    , N'Automata, Computability, and Complexity'
    , N'This course provides a challenging introduction to some of the central ideas of theoretical computer science. Beginning in antiquity, the course will progress through finite automata, circuits and decision trees, Turing machines and computability, efficient algorithms and reducibility, the P versus NP problem, NP-completeness, the power of randomness, cryptography and one-way functions, computational learning theory, and quantum computing. It examines the classes of problems that can and cannot be solved by various kinds of machines. It tries to explain the key differences between computational models that affect their power.'
    ,GETUTCDATE()
    ,GETUTCDATE()
    ),

    (NEWID()
    , N'Design and Analysis of Algorithms'
    , N'This is an intermediate algorithms course with an emphasis on teaching techniques for the design and analysis of efficient algorithms, emphasizing methods of application. Topics include divide-and-conquer, randomization, dynamic programming, greedy algorithms, incremental improvement, complexity, and cryptography.'
    ,GETUTCDATE()
    ,GETUTCDATE()
    ),

    (NEWID()
    , N'Computer System Engineering'
    , N'This course offers an introduction to the engineering of digital systems. Starting with MOS transistors, the course develops a series of building blocks — logic gates, combinational and sequential circuits, finite-state machines, computers and finally complete systems. Both hardware and software mechanisms are explored through a series of design examples.'
    ,GETUTCDATE()
    ,GETUTCDATE()
    ),

    (NEWID()
    , N'Computation Structures'
    , N'This is an intermediate algorithms course with an emphasis on teaching techniques for the design and analysis of efficient algorithms, emphasizing methods of application. Topics include divide-and-conquer, randomization, dynamic programming, greedy algorithms, incremental improvement, complexity, and cryptography.'
    ,GETUTCDATE()
    ,GETUTCDATE()
    ),

    (NEWID()
    , N'Artificial Intelligence'
    , N'This course introduces students to the basic knowledge representation, problem solving, and learning methods of artificial intelligence. Upon completion of 6.034, students should be able to develop intelligent systems by assembling solutions to concrete computational problems; understand the role of knowledge representation, problem solving, and learning in intelligent-system engineering; and appreciate the role of problem solving, vision, and language in understanding human intelligence from a computational perspective.'
    ,GETUTCDATE()
    ,GETUTCDATE()
    ),

    (NEWID()
    , N'Computer Language Engineering'
    , N'This course analyzes issues associated with the implementation of higher-level programming languages. Topics covered include: fundamental concepts, functions, and structures of compilers, the interaction of theory and practice, and using tools in building software. The course includes a multi-person project on compiler design and implementation.'
    ,GETUTCDATE()
    ,GETUTCDATE()
    ),

    (NEWID()
    , N'Network and Computer Security'
    , N'Network and Computer Security is an upper-level undergraduate, first-year graduate course on network and computer security. It fits within the Computer Systems and Architecture Engineering concentration.'
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
    (SELECT Id FROM [dbo].[Classes] WHERE [Name] = N'Computer Science class 2')
    ,(SELECT Id FROM [dbo].[Courses] WHERE [Name] = N'Automata, Computability, and Complexity')
    ,GETUTCDATE()
    ,GETUTCDATE()
    ),

    ((SELECT Id FROM [dbo].[Classes] WHERE [Name] = N'Computer Science class 2')
    ,(SELECT Id FROM [dbo].[Courses] WHERE [Name] = N'Design and Analysis of Algorithms')
    ,GETUTCDATE()
    ,GETUTCDATE()
    ),

    ((SELECT Id FROM [dbo].[Classes] WHERE [Name] = N'Computer Science class 2')
    ,(SELECT Id FROM [dbo].[Courses] WHERE [Name] = N'Introduction to Algorithms')
    ,GETUTCDATE()
    ,GETUTCDATE()
    ),

    ((SELECT Id FROM [dbo].[Classes] WHERE [Name] = N'Computer Science class 2')
    ,(SELECT Id FROM [dbo].[Courses] WHERE [Name] = N'Computer System Engineering')
    ,GETUTCDATE()
    ,GETUTCDATE()
    ),

    ((SELECT Id FROM [dbo].[Classes] WHERE [Name] = N'Computer Science class 2')
    ,(SELECT Id FROM [dbo].[Courses] WHERE [Name] = N'Computation Structures')
    ,GETUTCDATE()
    ,GETUTCDATE()
    ),

    ((SELECT Id FROM [dbo].[Classes] WHERE [Name] = N'Computer Science class 2')
    ,(SELECT Id FROM [dbo].[Courses] WHERE [Name] = N'Artificial Intelligence')
    ,GETUTCDATE()
    ,GETUTCDATE()
    ),

    ((SELECT Id FROM [dbo].[Classes] WHERE [Name] = N'Computer Science class 2')
    ,(SELECT Id FROM [dbo].[Courses] WHERE [Name] = N'Computer Language Engineering')
    ,GETUTCDATE()
    ,GETUTCDATE()
    ),

    ((SELECT Id FROM [dbo].[Classes] WHERE [Name] = N'Computer Science class 2')
    ,(SELECT Id FROM [dbo].[Courses] WHERE [Name] = N'Network and Computer Security')
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
    , N'Architectural Design Workshop: Collage - Method and Form'
    , N'This class investigates the theory, method, and form of collage. It studies not only the historical precedents for collage and their physical attributes, but the psychology and process that plays a part in the making of them. The class was broken into three parts, changing scales and methods each time, to introduce and study the rigor by which decisions were made in relation to the collage. The class was less about the making of art than the study of the processes by which art is made.'
    ,GETUTCDATE()
    ,GETUTCDATE()
    ),

    (NEWID()
    , N'Studio Seminar in Public Art'
    , N'How do we define Public Art? This course focuses on the production of projects for public places. Public Art is a concept that is in constant discussion and revision, as much as the evolution and transformation of public spaces and cities are. Monuments are repositories of memory and historical presences with the expectation of being permanent. Public interventions are created not to impose and be temporary, but as forms intended to activate discourse and discussion. Considering the concept of a museum as a public device and how they are searching for new ways of avoiding generic identities, we will deal with the concept of the personal imaginary museum. It should be considered as a point of departure to propose a personal individual construction based on the concept of defining a personal imaginary museum - concept, program, collection, events, architecture, public diffusion, etc.'
    ,GETUTCDATE()
    ,GETUTCDATE()
    ),

    (NEWID()
    , N'Interrogative Design Workshop'
    , N'"Parrhesia" was an Athenian right to frank and open speaking, the right that, like the First Amendment, demands a "fearless speaker" who must challenge political powers with criticism and unsolicited advice. Can designer and artist respond today to such a democratic call and demand? Is it possible to do so despite the (increasing) restrictions imposed on our liberties today? Can the designer or public artist operate as a proactive "parrhesiatic" agent and contribute to the protection, development and dissemination of "fearless speaking" in Public Space?'
    ,GETUTCDATE()
    ,GETUTCDATE()
    ),

	(NEWID()
    , N'Introduction to Art History'
    , N'This course investigates the power of art in historical perspective, focusing on Euro-American traditions of art from the fourteenth to the twenty-first century. It examines changing conceptions of the artist, the work of art, and the discipline of art history, exploring the roles images and objects have played over time, how they functioned in various social, economic, and cultural contexts, and whose interests they served or sought to disrupt.'
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
    (SELECT Id FROM [dbo].[Classes] WHERE [Name] = N'Fine Arts')
    ,(SELECT Id FROM [dbo].[Courses] WHERE [Name] = N'Architectural Design Workshop: Collage - Method and Form')
    ,GETUTCDATE()
    ,GETUTCDATE()
    ),

    ((SELECT Id FROM [dbo].[Classes] WHERE [Name] = N'Fine Arts')
    ,(SELECT Id FROM [dbo].[Courses] WHERE [Name] = N'Studio Seminar in Public Art')
    ,GETUTCDATE()
    ,GETUTCDATE()
    ),
	
	((SELECT Id FROM [dbo].[Classes] WHERE [Name] = N'Fine Arts')
    ,(SELECT Id FROM [dbo].[Courses] WHERE [Name] = N'Interrogative Design Workshop')
    ,GETUTCDATE()
    ,GETUTCDATE()
    ),

    ((SELECT Id FROM [dbo].[Classes] WHERE [Name] = N'Fine Arts')
    ,(SELECT Id FROM [dbo].[Courses] WHERE [Name] = N'Introduction to Art History')
    ,GETUTCDATE()
    ,GETUTCDATE()
    );