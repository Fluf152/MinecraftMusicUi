IF EXISTS (SELECT name FROM sys.databases WHERE name = 'MinecraftDiscs')
BEGIN
    ALTER DATABASE MinecraftDiscs SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    use master;
	DROP DATABASE MinecraftDiscs;
END
GO

CREATE DATABASE MinecraftDiscs;
GO

use MinecraftDiscs;

create table Disc(
	Id int constraint PK_Disc_Id primary key identity,
	Author varchar(255),
	Title varchar(255),
	Picture varchar(max),
	Music varchar(max)
)
go


INSERT INTO Disc (Author, Title, Picture, Music)
VALUES (
    'C418', 
    'Cat', 
	'Cat.png',
	'Cat.mp3'
);

INSERT INTO Disc (Author, Title, Picture, Music)
VALUES (
    'C418', 
    'Far', 
    'Far.png',
    'Far.mp3'
);

INSERT INTO Disc (Author, Title, Picture, Music)
VALUES (
    'C418', 
    'Stal', 
    'Stal.png',
    'Stal.mp3'
);

INSERT INTO Disc (Author, Title, Picture, Music)
VALUES (
    'C418', 
    'Strad', 
    'Strad.png',
    'Strad.mp3'
);

INSERT INTO Disc (Author, Title, Picture, Music)
VALUES (
    'C418', 
    'Ward', 
    'Ward.png', 
    'Ward.mp3'
);