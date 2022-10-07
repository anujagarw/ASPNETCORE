CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Products]    Script Date: 10/4/2022 3:13:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](250) NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL DEFAULT ('0001-01-01T00:00:00.0000000'),
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Index [IX_Products_CategoryId]    Script Date: 10/4/2022 3:13:15 PM ******/
CREATE NONCLUSTERED INDEX [IX_Products_CategoryId] ON [dbo].[Products]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories_CategoryId]
GO
/****** Object:  StoredProcedure [dbo].[AddNewProductDetails]    Script Date: 10/4/2022 3:13:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[AddNewProductDetails]  
(  
   @Name varchar (50),  
   @Description varchar (50),  
   @UnitPrice decimal,
   @CategoryId int     
)  
as  
begin  
   Insert into Products(Name,Description,UnitPrice, CategoryId, CreatedDate) values(@Name,@Description,@UnitPrice,@CategoryId, GETDATE())  
End 
GO
/****** Object:  StoredProcedure [dbo].[DeleteProductById]    Script Date: 10/4/2022 3:13:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[DeleteProductById]  
(  
   @ProductId int
)  
as  
begin  
   Delete from Products where ProductId=@ProductId;  
End 
GO
/****** Object:  StoredProcedure [dbo].[UpdateProductDetails]    Script Date: 10/4/2022 3:13:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UpdateProductDetails]  
(  
   @ProductId int,
   @Name varchar (50),  
   @Description varchar (50),  
   @UnitPrice decimal,
   @CategoryId int     
)  
as  
begin  
   Update Products Set Name=@Name, Description=@Description,UnitPrice=@UnitPrice, CategoryId=@CategoryId Where ProductId=@ProductId;  
End 
GO
/****** Object:  StoredProcedure [dbo].[usp_getproduct]    Script Date: 10/4/2022 3:13:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_getproduct]
@ProductId int
As
Begin
	Select * from Products Where ProductId = @ProductId;
End;

GO
USE [master]
GO
ALTER DATABASE [EFCore11Sep] SET  READ_WRITE 
GO
