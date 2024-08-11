CREATE DATABASE CARdb

USE CARdb

CREATE TABLE Cars
(
[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
[MODEL] NVARCHAR(50) NOT NULL,
[MARKA] NVARCHAR(50) NOT NULL


)
Insert into Cars (Marka,Model)
			Values ('Hyunday','Elantra')

Insert into Cars (Marka,Model)
			Values ('Hyunday','Sonata')

drop database CARdb