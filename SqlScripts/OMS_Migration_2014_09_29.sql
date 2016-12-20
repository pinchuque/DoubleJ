ALTER TABLE dbo.Product ADD Code CHAR(5) NULL
GO

UPDATE dbo.Product
SET Code = right('00000' + cast(rn AS VARCHAR(5)), 5)
FROM (SELECT Id, row_number() OVER(ORDER BY Id) AS rn FROM dbo.Product) AS x
WHERE dbo.Product.Id=x.Id

GO
DELETE FROM dbo.Label
GO
ALTER TABLE dbo.Label ADD PackedFor NVARCHAR(50) NOT NULL
GO
ALTER TABLE dbo.Label ADD Refrigeration NVARCHAR(50) NULL
GO
ALTER TABLE dbo.Label ADD VarCustomerProductValue VARCHAR(20) NULL
GO
ALTER TABLE dbo.Label ADD VarCustomerJobValue VARCHAR(20) NULL
GO
ALTER TABLE dbo.Customer ADD ProductValue VARCHAR(20) NULL
GO
ALTER TABLE dbo.Customer ADD JobValue VARCHAR(20) NULL
GO