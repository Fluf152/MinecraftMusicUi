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

create table Author(
	Id int constraint PK_Author_Id primary key identity,
	AuthorName varchar(255) not null
)

create table Disc(
	Id int constraint PK_Disc_Id primary key identity,
	AuthorId int constraint FK_Disc_To_Author foreign key references Author(Id),
	Title varchar(255),
	Picture varchar(max),
	Music varchar(max)
)
go

INSERT INTO Author(AuthorName)
VALUES('C418');

INSERT INTO Disc (AuthorId, Title, Picture, Music)
VALUES (
    1, 
    'Cat', 
	'Cat.png',
	'Cat.mp3'
);

INSERT INTO Disc (AuthorId, Title, Picture, Music)
VALUES (
    1, 
    'Far', 
    'Far.png',
    'Far.mp3'
);

INSERT INTO Disc (AuthorId, Title, Picture, Music)
VALUES (
    1, 
    'Stal', 
    'Stal.png',
    'Stal.mp3'
);

INSERT INTO Disc (AuthorId, Title, Picture, Music)
VALUES (
    1, 
    'Strad', 
    'Strad.png',
    'Strad.mp3'
);

INSERT INTO Disc (AuthorId, Title, Picture, Music)
VALUES (
    1, 
    'Ward', 
    'Ward.png', 
    'Ward.mp3'
);