-- Create Database
CREATE DATABASE Theater;

-- Use Database
USE Theater;
GO

-- ON PROJECT TERMINAL EXECUTE NEXT TWO COMMANDS
-- -- dotnet ef migrations add InitialCreate
-- -- dotnet ef database update

-- Insert Some Values To Database
INSERT INTO Actors (FirstName, LastName, DOB, Gender, SkinColor, EyeColor, HairColor) 
VALUES(
    'Jairo',
    'Perez',
    '2001-08-14',
    'Male',
    'Light Brown',
    'Dark Brown',
    'Black'
);

INSERT INTO Actors (FirstName, LastName, DOB, Gender, SkinColor, EyeColor, HairColor) 
VALUES(
    'Victor',
    'Chourio',
    '2001-03-05',
    'Male',
    'Dark Brown',
    'Dark Brown',
    'Black'
);

INSERT INTO Actors (FirstName, LastName, DOB, Gender, SkinColor, EyeColor, HairColor) 
VALUES(
    'Grecia',
    'Mendez',
    '2004-05-07',
    'Female',
    'Light Brown',
    'Dark Brown',
    'Brown'
);

INSERT INTO Plays (Title, Genre, Format, Description)
VALUES(
    'Eso Que Llaman Amor',
    'Romantic Comedy',
    'Small',
    'Two youngs that are so different but they fall in love after they break up with their previous crazy partners'
);

INSERT INTO Plays (Title, Genre, Format, Description) 
VALUES(
    'Los Hermanos Castello Branco',
    'Romantic Comedy',
    'Medium',
    'Three brothers tell their own story of how they found love in the most unexpected way'
);

INSERT INTO Plays (Title, Genre, Format, Description)
VALUES(
    'Verona',
    'Drama',
    'Large',
    'A modern version of Romeo and Juliet, where the Montesco and Capuleto families are the most powerful in the city'
)

GO

-- After the previous values are inserted check the ids and add them here
INSERT INTO Characters (Name, Description, Age, Gender, Principal, ActorId, PlayId) 
VALUES(
    'Juan Pedro Castello Branco',
    'He is the second of two brothers, Musician, but not a regular one, he is composer and singer of TV jingles',
    26,
    'Male',
    1,
    1,
    2
);

INSERT INTO Characters (Name, Description, Age, Gender, Principal, ActorId, PlayId) 
VALUES(
    'Teobaldo Capuleto',
    'He is the cousing of Juliet, he is the second in charge of the Capuleto family, he has a difficult temperament',
    28,
    'Male',
    0,
    1,
    3
);

INSERT INTO Characters (Name, Description, Age, Gender, Principal, ActorId, PlayId) 
VALUES(
    'Romeo Montesco',
    'He is the youngest son of the Montesco family, he is a dreamer and a romantic, he is in love with Juliet',
    21,
    'Male',
    1,
    2,
    3
);

INSERT INTO Musics (PlayId, Title, Artist)
VALUES(
    3,
    'De Musica Ligera',
    'Soda Stereo'
);

INSERT INTO [References] (PlayId, Title, Author, Description, Type, ReleaseDate, Genre)
VALUES(
    3,
    'Romeo and Juliet',
    'William Shakespeare',
    'The most famous love story of all time',
    'Book',
    '1597-01-01',
    'Drama'
);

GO