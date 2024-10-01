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
	Picture varbinary(max),
	Music varbinary(max)
)
go


INSERT INTO Disc (Author, Title, Picture, Music)
VALUES (
    'C418', 
    'Cat', 
    (SELECT * FROM OPENROWSET(BULK 'C:\MyProjects\C#\MinecraftMusicUi\ForDb\Images\Cat.png', SINGLE_BLOB) AS Picture),
    (SELECT * FROM OPENROWSET(BULK 'C:\MyProjects\C#\MinecraftMusicUi\ForDb\Music\Cat.mp3', SINGLE_BLOB) AS Music)
);

INSERT INTO Disc (Author, Title, Picture, Music)
VALUES (
    'C418', 
    'Far', 
    (SELECT * FROM OPENROWSET(BULK 'C:\MyProjects\C#\MinecraftMusicUi\ForDb\Images\Far.png', SINGLE_BLOB) AS Picture),
    (SELECT * FROM OPENROWSET(BULK 'C:\MyProjects\C#\MinecraftMusicUi\ForDb\Music\Far.mp3', SINGLE_BLOB) AS Music)
);

INSERT INTO Disc (Author, Title, Picture, Music)
VALUES (
    'C418', 
    'Stal', 
    (SELECT * FROM OPENROWSET(BULK 'C:\MyProjects\C#\MinecraftMusicUi\ForDb\Images\Stal.png', SINGLE_BLOB) AS Picture),
    (SELECT * FROM OPENROWSET(BULK 'C:\MyProjects\C#\MinecraftMusicUi\ForDb\Music\Stal.mp3', SINGLE_BLOB) AS Music)
);

INSERT INTO Disc (Author, Title, Picture, Music)
VALUES (
    'C418', 
    'Strad', 
    (SELECT * FROM OPENROWSET(BULK 'C:\MyProjects\C#\MinecraftMusicUi\ForDb\Images\Strad.png', SINGLE_BLOB) AS Picture),
    (SELECT * FROM OPENROWSET(BULK 'C:\MyProjects\C#\MinecraftMusicUi\ForDb\Music\Strad.mp3', SINGLE_BLOB) AS Music)
);

INSERT INTO Disc (Author, Title, Picture, Music)
VALUES (
    'C418', 
    'Ward', 
    (SELECT * FROM OPENROWSET(BULK 'C:\MyProjects\C#\MinecraftMusicUi\ForDb\Images\Ward.png', SINGLE_BLOB) AS Picture),
    (SELECT * FROM OPENROWSET(BULK 'C:\MyProjects\C#\MinecraftMusicUi\ForDb\Music\Ward.mp3', SINGLE_BLOB) AS Music)
);