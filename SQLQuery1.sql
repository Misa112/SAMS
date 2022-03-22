Create Database StudentAccommodationDB

GO
use StudentAccommodationDB;

DROP TABLE [dbo].[Leasing];
DROP TABLE [dbo].[Room];
DROP TABLE [dbo].[Dormitory]
DROP TABLE [dbo].[Appartment];
DROP TABLE [dbo].[Student];

CREATE TABLE Dormitory(
     Dormitory_No  int  NOT NULL PRIMARY KEY,
     Name      VARCHAR(30)     NOT NULL,
     Address   VARCHAR(50)  NOT NULL
);

CREATE TABLE Appartment(
     Appart_No  int  NOT NULL PRIMARY KEY,
     Address   VARCHAR(50)  NOT NULL,
      Types     CHAR(1)   DEFAULT '3',
      CONSTRAINT checkType 
	  CHECK (Types IN ('3','4','5') OR Types IS NULL)
);

CREATE TABLE [dbo].[Room] (
    [Place_No]          INT NOT NULL,
    [Rent_Per_Semester] INT NOT NULL,
    [Occupied]          BIT NOT NULL,
    [Room_No]           INT NOT NULL,
    [Dormitory_No] INT NULL, 
    [Appart_No] INT NULL, 
    PRIMARY KEY CLUSTERED ([Place_No] ASC), 
    CONSTRAINT [FK_Room_Dormitory] FOREIGN KEY ([Dormitory_No]) REFERENCES [Dormitory]([Dormitory_No]), 
    CONSTRAINT [FK_Room_Appartment] FOREIGN KEY ([Appart_No]) REFERENCES [Appartment]([Appart_No])
);



CREATE TABLE [dbo].[Student] (
    [Student_No] INT NOT NULL,
    [SName] VARCHAR(50) NOT NULL, 
    [SAddress] VARCHAR(50) NOT NULL, 
    [Has_Room] BIT NOT NULL, 
    [Registration_Date]  DateTime  NOT NULL, 

    PRIMARY KEY CLUSTERED ([Student_No] ASC)
);

CREATE TABLE [dbo].[Leasing] (
    [Leasing_No] INT      IDENTITY (1, 1) NOT NULL,
    [Student_No] INT      NOT NULL,
    [Place_No]   INT      NOT NULL,
    [Date_From]  DATETIME NOT NULL,
    [Date_To]    DATETIME NOT NULL,
    PRIMARY KEY CLUSTERED ([Leasing_No] ASC),
    CONSTRAINT [FK_Leasing_Room] FOREIGN KEY ([Place_No]) REFERENCES [dbo].[Room] ([Place_No]),
    CONSTRAINT [FK_Leasing_Student] FOREIGN KEY ([Student_No]) REFERENCES [dbo].[Student] ([Student_No])
);

	
--ALTER TABLE Leasing 
--	ADD CONSTRAINT incorrect_dates
--       CHECK ((Date_To > Date_From) AND (Date_From <= '2022-12-31') AND(Date_From >= '2022-07-01')  AND(Date_TO <= '2022-12-31'));

-- We want to lease our rooms only for the next semester 
    ALTER TABLE Leasing 
	ADD CONSTRAINT incorrect_dates
       CHECK ((Date_To > Date_From) AND (Date_From = '2022-07-01')AND(Date_TO = '2022-12-31'));

Go

--These are the 3 apartments 
INSERT INTO Appartment   VALUES (1,' Smedegade 7 st th ', '5');
INSERT INTO Appartment   VALUES (2,'Rådhusbuen 1 4000 Roskilde', '4');
INSERT INTO Appartment   VALUES (3,'Maglegårdsvej 2, 4000 Roskilde', '3');

--These are the 2 dormitories
INSERT INTO Dormitory   VALUES (1,'Musicon','Vaticanstreet 1  1111 Bishopcity');
INSERT INTO Dormitory   VALUES (2,'Lucky Star','Lucky Road 12  2222 Hometown');


-- These are the rooms in the dormitory 1
INSERT INTO Room   VALUES (1, 300 , 0, 1, 1, null);
INSERT INTO Room   VALUES (2, 200 , 0, 2, 1, null);
INSERT INTO Room   VALUES (3, 250 , 0, 3, 1, null);
INSERT INTO Room   VALUES (4, 220 , 0, 4, 1, null);
INSERT INTO Room   VALUES (5, 340 , 0, 5, 1, null);
INSERT INTO Room   VALUES (6, 360 , 0, 6, 1, null);

--These are the rooms in the dormitory 2
INSERT INTO Room   VALUES (7, 350 , 0, 1, 2, null);
INSERT INTO Room   VALUES (8, 220 , 0, 2, 2, null);
INSERT INTO Room   VALUES (9, 210 , 0, 3, 2, null);
INSERT INTO Room   VALUES (10, 215 , 0, 4, 2, null);

--These are the rooms in the apartment 1
INSERT INTO Room   VALUES (11,200 , 0, 1 ,null, 1);
INSERT INTO Room   VALUES (12,210 , 0, 2 ,null, 1);
INSERT INTO Room   VALUES (13,270 , 0, 3 ,null, 1);
INSERT INTO Room   VALUES (14,300 , 0, 4 ,null, 1);
INSERT INTO Room   VALUES (15,320 , 0, 5 ,null, 1);

--These are the rooms in the apartment 2
INSERT INTO Room   VALUES (16,200 , 0, 1 ,null, 2);
INSERT INTO Room   VALUES (17,210 , 0, 2 ,null, 2);
INSERT INTO Room   VALUES (18,270 , 0, 3 ,null, 2);
INSERT INTO Room   VALUES (19,300 , 0, 4 ,null, 2);

--These are the rooms in the apartment 3
INSERT INTO Room   VALUES (20,200 , 0, 1 ,null, 3);
INSERT INTO Room   VALUES (21,210 , 0, 2 ,null, 3);
INSERT INTO Room   VALUES (22,270 , 0, 3 ,null, 3);


INSERT INTO Student  VALUES( 1,'Eva','Paradisvej 3, 1111 Bispeborg', 0, '04-04-2019');
INSERT INTO Student  VALUES( 2,'Adam','Paradisvej 7, 1111 Bispeborg' , 0, '03-04-2019');
INSERT INTO Student  VALUES( 3,'Goeg','Sunset Blvd. 8, 2222 Hjemby', 0 ,'01-03-2019' );
INSERT INTO Student  VALUES( 4,'Gokke', ' Sunset Blvd. 8, 2222 Hjemby',0, '05-01-2018');
INSERT INTO Student  VALUES( 5,'Fy','Klovnevej 87, 3333 Lilleby', 0, '08-09-2017' );
INSERT INTO Student  VALUES( 6,'Bi','Bredgade 198, 3333 Lilleby', 0, '08-09-2017');
INSERT INTO Student  VALUES( 7,'Romeo','Kaerlighedstunellen 1, 4444 Borgerslev', 0, '08-09-2016');
INSERT INTO Student  VALUES( 8,'Julie','Kaerlighedstuen 2,4444 Borgerslev', 0,'08-09-2015');
INSERT INTO Student  VALUES( 9,'Godzilla','Dommervænget 16A, 4000 Roskilde', 0, '08-10-2017');
INSERT INTO Student  VALUES(10,'KingKong','Hyrdevænget 38, 4000 Roskilde', 0, '09-09-2017');
INSERT INTO Student  VALUES(11,'KongHans','Algade 10, 4000 Roskilde', 0, '08-01-2017');
INSERT INTO Student  VALUES(12,'Hans' ,'Vikingevej 45, 4000 Roskilde', 0, '03-09-2013');
INSERT INTO Student  VALUES(13,'Poul','Domkirkevej 12, 4000 Roskilde', 0 , '12-03-2018' );
INSERT INTO Student VALUES(14,'Erik' ,'Hestetorvet 8, 4000 Roskilde', 0 ,  '12-02-2018');
INSERT INTO Student  VALUES(15,'Ulla'  ,'Stændertorvet 4, 4000 Roskilde',0, ' 03-22-2018');
INSERT INTO Student VALUES(16,'Yrsa' ,'Sdr. Ringvej 21, 4000 Roskilde',0, '01-22-2020');
INSERT INTO Student VALUES(17,'Yvonne' ,'Østre Ringvej 12, 4000 Roskilde',0 , '06-14-2018');
INSERT INTO Student VALUES(18,'Tim' ,'Ringstedgade 33, 4000 Roskilde',0 , '11-25-2017');
INSERT INTO Student VALUES(19,'Sten' ,'Ringstedvej 23, 4000 Roskilde',0 , '08-14-2018');
INSERT INTO Student VALUES(20,'Erland','Skovbovængets alle 3,4000 Roskilde',0, '04-19-2019');
INSERT INTO Student VALUES(21,'Erwin','Ternevej 17, 4000 Roskilde',0, '12-12-2018');
INSERT INTO Student VALUES(22,'Åge' ,'Solsortevej 9, 4000 Roskilde',0, '05-06-2019');
INSERT INTO Student VALUES(23,'Åse','Gyvelvej 45, 4000 Roskilde',0, '12-03 - 2021');
INSERT INTO Student VALUES(24,'Frede','Københavnsvej 25, 4000 Roskilde',0, '12-04-2019');
INSERT INTO Student VALUES(25,'Palle','Sct Ohlsgade 10, 4000 Roskilde',0 , '05-03-2019');
INSERT INTO Student VALUES(26,'Jørn','Dronning Amaliesvej 22,4000 Roskilde',0, '12-10-2019');
INSERT INTO Student VALUES(27,'Stefan' ,'Lærkevej 65, 4000 Roskilde',0, '03-06-2017');
INSERT INTO Student VALUES(28,'John' ,'By03ken 56, 4000 Roskilde',0 , '12-11-2019');
INSERT INTO Student VALUES(29,'Dana' ,'Byageren 12, 4000 Roskilde',0, '12-09-2018');
INSERT INTO Student VALUES(30,'Arn' ,'Vindingevej 23, 4000 Roskilde',0, '10-10-2019');
INSERT INTO Student  VALUES(31,'Adam','Hyrdevænget 24, 4000 Roskilde',0, '11-11-2018');
INSERT INTO Student  VALUES(32,'Patrick','Algade 11, 4000 Roskilde',0 , '09-09-2019');
INSERT INTO Student  VALUES(33,'David'    ,'Vikingevej 78, 4000 Roskilde',0, '09-18-2019');
INSERT INTO Student  VALUES(34,'Simon'    ,'Domkirkevej 09, 4000 Roskilde',0 , '07-19-2019');
INSERT INTO Student VALUES(35,'Ulrik'    ,'Hestetorvet 18, 4000 Roskilde',0 , '06-20-2018');
INSERT INTO Student  VALUES(36,'Anna'    ,'Stændertorvet 4, 4000 Roskilde',0 , '09-23-2019');
INSERT INTO Student VALUES(37,'Martin' ,'Sdr. Ringgade 21, 4000 Roskilde',0 , '11-26-2020');
INSERT INTO Student VALUES(38,'Digna'  ,' Ringvej 32, 4000 Roskilde',0 , '08-09-2018');
INSERT INTO Student VALUES(39,'Timoty' ,'Ringstedgade 83, 4000 Roskilde',0 , '09-19-2019');
INSERT INTO Student VALUES(40,'Stine'    ,'Ringstedvej 13, 4000 Roskilde',0 , '06-29-2018');
INSERT INTO Student VALUES(41,'Kevin','Skovbovængets alle 13,4000 Roskilde',0 , '03-22-2019');


