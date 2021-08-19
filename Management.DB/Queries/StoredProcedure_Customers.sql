-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sarah Adebesin
-- Create date: 15/8/2021
-- Description:	This is to help execute Insert statements into the Customers data.
-- =============================================

--Stored procedure to add a customer to the table
CREATE PROCEDURE InsertCustomer
@firstName VARCHAR(80), @lastName VARCHAR(80), @email VARCHAR(120), @Password VARCHAR
AS
BEGIN
				
INSERT INTO Customers VALUES(@firstName, @lastName, @email, @Password);

END
GO;

--Stored procedure to select all customers
CREATE PROCEDURE SelectAllCustomers
AS
BEGIN

SELECT * FROM Customers;

END
GO;

--Stored procedure to update a customer data
CREATE PROCEDURE UpdateCustomer
@firstName VARCHAR(80), @email VARCHAR(120)
AS
BEGIN

UPDATE Customers SET FirstName = @firstName, Email = @email WHERE Id = @Id;

END
GO;

--Stored procedure to select a particular customer
CREATE PROCEDURE SelectCustomer
AS
BEGIN

SELECT * FROM Customers WHERE Id = @Id;

END
GO;

--Stored procedure to delete a customer
CREATE PROCEDURE DeleteCustomer
AS
BEGIN

DELETE FROM Customers WHERE Id = @Id;

END
GO;