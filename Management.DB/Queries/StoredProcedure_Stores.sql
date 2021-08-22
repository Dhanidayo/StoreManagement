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
-- Description:	This is to help execute query statements into the Stores data.
-- =============================================
--Stored procedure to create a store in the store table
CREATE PROCEDURE InsertStore
@storeType VARCHAR(11), @storeName VARCHAR(80), @storeId VARCHAR(80), @products INT, @Id VARCHAR(80)

AS
BEGIN
				
INSERT INTO Stores VALUES(@storeType, @storeName, @storeId, @products, @userId);

END
GO;

--Stored procedure to select all stores
CREATE PROCEDURE SelectAllStores
AS
BEGIN

SELECT * FROM Stores;

END
GO;

--Stored procedure to update a store data
CREATE PROCEDURE UpdateStore
@storeName VARCHAR(80), @products INT
AS
BEGIN

UPDATE Stores SET Products = @products WHERE Id = @userId;

END
GO;

--Stored procedure to select all stores belonging to a user.
CREATE PROCEDURE SelectStores
AS
BEGIN

SELECT * FROM Stores WHERE Id = @userId;

END
GO;

--Stored procedure to delete all stores belonging to a user.
CREATE PROCEDURE DeleteStoresBelongingToACustomer
AS
BEGIN

DELETE FROM Stores WHERE Id = @userId;

END
GO;

--Stored procedure to delete a store.
CREATE PROCEDURE DeleteStore
AS
BEGIN

DELETE FROM Stores WHERE Id = @storeId;

END
GO;