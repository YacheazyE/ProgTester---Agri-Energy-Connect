USE master;
GO

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'Farm')
BEGIN
	CREATE DATABASE Farm;
END
GO

USE Farm;
GO

CREATE TABLE Cows(
	CowID INT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(50) NOT NULL,
	Breed VARCHAR(50) NOT NULL,
	Age INT NOT NULL,
	MilkProduction DECIMAL(5,2)  NOT NULL,
	IsPregnant BIT NOT NULL,
	LastVetCheck Date NOT NULL

);
GO

CREATE TABLE Farms(
	FarmID INT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(50) NOT NULL,
	CreatedDate Date NOT NULL
);
GO


INSERT INTO Cows(Name, Breed, Age, MilkProduction, IsPregnant, LastVetCheck)
VALUES
('Bessie', 'Holstein', 5, 24.5, 1, '2025-05-12'),
('Daisy', 'Jersey', 2, 20.5, 0, '2025-05-12'),
('Bella', 'Guernsy', 4, 24.5, 1, '2025-05-12');
GO

INSERT INTO Farms(Name, CreatedDate)
VALUES
('Kobus',  '2025-05-12'),
('Piet',  '2025-05-12');
GO