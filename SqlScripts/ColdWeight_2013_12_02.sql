sp_RENAME '[ColdWeightDetail].[Weight]' , 'FirstSideWeight', 'COLUMN'
GO
ALTER TABLE dbo.ColdWeightDetail
ADD SecondSideWeight DECIMAL(18,2), AnimalNumber VARCHAR(30), EarTag VARCHAR(30)