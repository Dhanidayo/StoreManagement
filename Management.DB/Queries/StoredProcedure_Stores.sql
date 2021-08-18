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
-- Description:	This is to help execute insert statements into the Stores data.
-- =============================================
CREATE PROCEDURE InsertStore
@storeType VARCHAR(11), @storeName VARCHAR(80), @storeId VARCHAR(80), @products INT

AS
BEGIN
				
INSERT INTO Stores VALUES(@storeType, @storeName, @storeId, @products);

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

UPDATE Stores SET StoreName = @storeName, Products = @products WHERE Id = @Id;

END
GO;

--Stored procedure to select a particular store
CREATE PROCEDURE SelectStore
AS
BEGIN

SELECT * FROM Stores WHERE Id = @Id;

END
GO;

--Stored procedure to delete a store
CREATE PROCEDURE DeleteStore
AS
BEGIN

DELETE FROM Stores WHERE Id = @Id;

END
GO;