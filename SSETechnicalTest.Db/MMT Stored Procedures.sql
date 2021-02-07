-- MMTShop SP Script --
-- spGetAvailableCategories --
IF NOT EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID('spGetAvailableCategories'))
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Foysal Ahmed
-- Create date: 06/02/2021
-- Description:	Retrieve a list of all available categories
-- =============================================
CREATE PROCEDURE [dbo].[spGetAvailableCategories]
AS
BEGIN TRY 
	SET NOCOUNT ON;

	SELECT Name 
	FROM Category
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000);
	DECLARE @ErrorSeverity INT;
	DECLARE @ErrorState INT;
	DECLARE @ErrorNumber INT;

	SELECT  @ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE(),
			@ErrorNumber = ERROR_NUMBER();

	RAISERROR
	(
		@ErrorMessage, -- Message text.
		@ErrorSeverity, -- Severity.
		@ErrorState, -- State.
		@ErrorNumber -- Error Number.
	);

	RETURN;
END CATCH
GO

-- spGetProducts --
IF NOT EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID('spGetProducts'))
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Foysal Ahmed
-- Create date: 06/02/2021
-- Description:	Retrieve all featured products
-- =============================================
CREATE PROCEDURE [dbo].[spGetProducts]
	@Featured AS BIT = NULL,
	@CategoryName AS NVARCHAR(50) = NULL
AS
BEGIN TRY 
	SET NOCOUNT ON;

	IF (@Featured IS NOT NULL)
	BEGIN
		SELECT		p.SKU, p.Name, p.Description, p.Price, p.CategoryID 
		FROM		Product p
		INNER JOIN	Category c ON p.CategoryID = c.CategoryID
		WHERE		c.Featured = 1
	END

	IF (@CategoryName IS NOT NULL)
	BEGIN
		IF NOT EXISTS (SELECT 1 FROM Category WHERE Name = @CategoryName)
			THROW 51000, 'Category does not exist', 1;		

		SELECT		p.SKU, p.Name, p.Description, p.Price, p.CategoryID 
		FROM		Product p
		INNER JOIN	Category c ON p.CategoryID = c.CategoryID
		WHERE		c.Name = @CategoryName
	END
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000);
	DECLARE @ErrorSeverity INT;
	DECLARE @ErrorState INT;
	DECLARE @ErrorNumber INT;

	SELECT  @ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE(),
			@ErrorNumber = ERROR_NUMBER();

	RAISERROR
	(
		@ErrorMessage, -- Message text.
		@ErrorSeverity, -- Severity.
		@ErrorState, -- State.
		@ErrorNumber -- Error Number.
	);

	RETURN;
END CATCH
GO

