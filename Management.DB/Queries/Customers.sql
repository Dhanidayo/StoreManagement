	--DDL
	--Creating Tables
USE WomenTechsters;

CREATE TABLE Customers
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	FirstName VARCHAR(80) NOT NULL,
	LastName VARCHAR(80) NOT NULL,
	Email VARCHAR(120) NOT NULL,
);

	--DML
	--Inserting into table.
	--Inserting by specifying the values to be inserted.
INSERT INTO Customers (FirstName, LastName, Email) VALUES ('Sarah', 'Adebesin', 'sarah@gmail.com', 'sarah1234');
INSERT INTO Customers (FirstName, LastName, Email) VALUES ('Tobi', 'Odunsi', 'tobi@gmail.com', 'tobi1234');
INSERT INTO Customers (FirstName, LastName, Email) VALUES ('Uzor', 'Amaka', 'uzor@gmail.com', 'uzor1234');

	--Altering the table to accommodate a new column
ALTER TABLE Customers
ADD Password VARCHAR(11);

	--Updating table.
UPDATE Customers SET LastName = 'Rice' WHERE Id = 1;

	--Deleting from Table.
DELETE FROM Customers WHERE Id = 2;

	--Read using SELECT
SELECT * FROM Customers;
SELECT Email FROM Customers;
SELECT FirstName, LastName FROM Customers;
SELECT LastName FROM Customers WHERE FirstName = 'Sarah';
SELECT FirstName FROM Customers WHERE Id = 3;