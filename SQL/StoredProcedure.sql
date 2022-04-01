CREATE PROCEDURE GetItemDetails
@ProductId int
AS
BEGIN 
	SELECT
	[ProductId]
      ,[Name]
      ,[Price]
      ,[ImageUrl]
      ,[Categoryid]
      ,[Description]
      ,[Currency]
	FROM [ProductsDb].[dbo].[Products]
	WHERE [ProductId] = @ProductId
END