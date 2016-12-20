DELETE FROM dbo.SiteNavigation

INSERT INTO dbo.SiteNavigation (Id, Name, Url, SortOrder, IsActive) VALUES (2, 'Cold Weight', '~/Internal/ColdWeight', 1, 1)
INSERT INTO dbo.SiteNavigation (Id, Name, Url, SortOrder, IsActive) VALUES (5, 'Customer Management', '~/Internal/Customer', 2, 1)
INSERT INTO dbo.SiteNavigation (Id, Name, Url, SortOrder, IsActive) VALUES (4, 'Product Management', '~/Internal/Products', 3, 1)
INSERT INTO dbo.SiteNavigation (Id, Name, Url, SortOrder, IsActive) VALUES (1, 'Orders', '~/Internal/Orders', 4, 1)
INSERT INTO dbo.SiteNavigation (Id, Name, Url, SortOrder, IsActive) VALUES (3, 'Labeling', '~/Internal/Labels', 5, 1)

GO
----------------------------------------------------------------------------------------------------------------------------------------
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Offal](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Offals] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
----------------------------------------------------------------------------------------------------------------------------------------
INSERT INTO [dbo].[Offal] ([Id],[Name],[IsActive]) VALUES (1, 'Oxtails', 1)
INSERT INTO [dbo].[Offal] ([Id],[Name],[IsActive]) VALUES (2, 'Cheek Meat', 1)
INSERT INTO [dbo].[Offal] ([Id],[Name],[IsActive]) VALUES (3, 'Tongue', 1)
INSERT INTO [dbo].[Offal] ([Id],[Name],[IsActive]) VALUES (4, 'Bullfries', 1)
INSERT INTO [dbo].[Offal] ([Id],[Name],[IsActive]) VALUES (5, 'Ox Lips', 1)
INSERT INTO [dbo].[Offal] ([Id],[Name],[IsActive]) VALUES (6, 'Livers', 1)
INSERT INTO [dbo].[Offal] ([Id],[Name],[IsActive]) VALUES (7, 'Heart', 1)
----------------------------------------------------------------------------------------------------------------------------------------
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[OrderOffal](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[OffalId] [int] NOT NULL,
	[CustomerLocationId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Weight] [decimal](18, 2) NOT NULL,
	CONSTRAINT [PK_OrderOffal] PRIMARY KEY CLUSTERED ([Id] ASC)WITH (PAD_INDEX=OFF, STATISTICS_NORECOMPUTE=OFF, IGNORE_DUP_KEY=OFF,
	 ALLOW_ROW_LOCKS=ON, ALLOW_PAGE_LOCKS=ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[OrderOffal]  WITH CHECK ADD CONSTRAINT [FK_OrderOffal_CustomerLocation] FOREIGN KEY([CustomerLocationId])
REFERENCES [dbo].[CustomerLocation] ([Id])
GO

ALTER TABLE [dbo].[OrderOffal] CHECK CONSTRAINT [FK_OrderOffal_CustomerLocation]
GO

ALTER TABLE [dbo].[OrderOffal]  WITH CHECK ADD  CONSTRAINT [FK_OrderOffal_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([Id])
GO

ALTER TABLE [dbo].[OrderOffal] CHECK CONSTRAINT [FK_OrderOffal_Order]
GO

ALTER TABLE [dbo].[OrderOffal]  WITH CHECK ADD  CONSTRAINT [FK_OrderOffal_Offal] FOREIGN KEY([OffalId])
REFERENCES [dbo].[Offal] ([Id])
GO

ALTER TABLE [dbo].[OrderOffal] CHECK CONSTRAINT [FK_OrderOffal_Offal]
GO
----------------------------------------------------------------------------------------------------------------------------------------
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[OrderCombo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[CustomerLocationId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Weight] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_OrderCombo] PRIMARY KEY CLUSTERED ([Id] ASC)
	WITH (PAD_INDEX=OFF, STATISTICS_NORECOMPUTE=OFF, IGNORE_DUP_KEY=OFF, ALLOW_ROW_LOCKS=ON, ALLOW_PAGE_LOCKS=ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[OrderCombo]  WITH CHECK ADD  CONSTRAINT [FK_OrderCombo_CustomerLocation] FOREIGN KEY([CustomerLocationId])
REFERENCES [dbo].[CustomerLocation] ([Id])
GO

ALTER TABLE [dbo].[OrderCombo] CHECK CONSTRAINT [FK_OrderCombo_CustomerLocation]
GO

ALTER TABLE [dbo].[OrderCombo]  WITH CHECK ADD  CONSTRAINT [FK_OrderCombo_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([Id])
GO

ALTER TABLE [dbo].[OrderCombo] CHECK CONSTRAINT [FK_OrderCombo_Order]
GO

ALTER TABLE [dbo].[OrderCombo]  WITH CHECK ADD  CONSTRAINT [FK_OrderCombo_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO

ALTER TABLE [dbo].[OrderCombo] CHECK CONSTRAINT [FK_OrderCombo_Product]
GO
----------------------------------------------------------------------------------------------------------------------------------------
ALTER TABLE [dbo].[Order] ADD ComboCompleted bit NOT NULL DEFAULT 0
GO

----------------------------------------------------------------------------------------------------------------------------------------
INSERT INTO dbo.SiteNavigation (Id, Name, Url, SortOrder, IsActive) VALUES (6, 'Shop floor', '~/Internal/ShopFloor', 6, 1)
GO

----------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------

