EXEC sp_rename 'CustomerProductCode', 'CustomerProductData'
GO
ALTER TABLE CustomerProductData ADD GTIN numeric(14)
GO
ALTER TABLE CustomerProductData ADD PricePerPound money 
GO
ALTER TABLE Label ADD GTIN numeric(14) not null default(90853685002011)
GO
ALTER TABLE Label ADD PricePerPound money 
GO
ALTER TABLE Label ADD Price money 
GO
ALTER TABLE Product ADD GTIN numeric(14) not null default(90853685002011)
GO
ALTER TABLE Product ADD PricePerPound money 
GO
UPDATE [dbo].[SiteNavigation] SET IsActive = 0 WHERE Name = 'Fulfillment'
GO

