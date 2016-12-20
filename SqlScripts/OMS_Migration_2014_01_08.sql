CREATE TABLE [dbo].[Refrigeration](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Refrigeration] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]




GO
insert into dbo.Refrigeration (Name) values ('Keep Refrigerated')
insert into dbo.Refrigeration (Name) values ('Keep Froze')


go

alter table [dbo].[Order] ADD RefrigerationId int null
	constraint [FK_Order_Refrigeration] FOREIGN KEY([RefrigerationId])
	references [dbo].[Refrigeration] ([Id])

go
	
alter table [dbo].[Order] ADD SlaughteredRegionId int null
	constraint [FK_Order_SlaughteredRegion] FOREIGN KEY([SlaughteredRegionId])
	references [dbo].[Region] ([Id])
	
go	
alter table dbo.Label alter column SerialNumber varchar(20) null

