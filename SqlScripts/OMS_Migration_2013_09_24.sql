ALTER TABLE dbo.Label ADD SubPrimal varchar(20)
GO
ALTER TABLE dbo.Label ADD Trim varchar(20)
GO
ALTER TABLE dbo.Label ADD GradeName varchar(20)
GO
ALTER TABLE dbo.Label ADD SerialNumber varchar(15)
GO
ALTER TABLE dbo.Label ADD Organic varchar(100)
GO
ALTER TABLE dbo.Label ADD CustomerProductCode varchar(30)
GO
ALTER TABLE dbo.Label ADD Customer varchar(25)
GO
sp_RENAME 'dbo.Label.ProcessDate', 'ProcessDateOld' , 'COLUMN'
GO
ALTER TABLE dbo.Label ADD ProcessDate varchar(10)
GO
sp_RENAME 'dbo.Label.SlaughterDate', 'SlaughterDateOld' , 'COLUMN'
GO
ALTER TABLE dbo.Label ADD SlaughterDate varchar(10)
GO
UPDATE dbo.Label SET ProcessDate = CONVERT(VARCHAR(10), ProcessDateOld, 101)
GO
UPDATE dbo.Label SET SlaughterDate = CONVERT(VARCHAR(10), SlaughterDateOld, 101)
GO
ALTER TABLE dbo.Label DROP COLUMN ProcessDateOld
GO
ALTER TABLE dbo.Label DROP COLUMN SlaughterDateOld
GO
ALTER TABLE dbo.Label ALTER COLUMN BornIn varchar(50)
GO
ALTER TABLE dbo.Label ALTER COLUMN ProductOf varchar(10)
GO
ALTER TABLE dbo.Label ALTER COLUMN FdaBugPath varchar(100)
GO
ALTER TABLE dbo.Label ALTER COLUMN LogoPath varchar(100)
GO

