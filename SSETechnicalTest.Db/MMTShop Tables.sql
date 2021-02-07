-- MMTShop Table Script --
-- Category --
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID('Category'))
CREATE TABLE [dbo].[Category](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Featured] [bit] NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Categories_Featured]  DEFAULT ((0)) FOR [Featured]
GO

-- Test values
IF NOT EXISTS (SELECT * FROM Category)
BEGIN
	SET IDENTITY_INSERT Category ON;

	INSERT INTO Category(CategoryID, Name, Featured) VALUES (1, 'Home', 1);
	INSERT INTO Category(CategoryID, Name, Featured) VALUES (2, 'Garden', 1);
	INSERT INTO Category(CategoryID, Name, Featured) VALUES (3, 'Electronics', 1);
	INSERT INTO Category(CategoryID, Name, Featured) VALUES (4, 'Fitness', 0);
	INSERT INTO Category(CategoryID, Name, Featured) VALUES (5, 'Toys', 0);
	   
	SET IDENTITY_INSERT Category OFF;
END
GO

-- Product --
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID('Product'))
CREATE TABLE [dbo].[Product](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[SKU] [nvarchar](64) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Description] [nvarchar](256) NULL,
	[Price] [decimal](10, 2) NULL,
	[CategoryID] [int] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Test values
IF NOT EXISTS (SELECT * FROM Product)
BEGIN
	SET IDENTITY_INSERT [dbo].[Product] ON 

	INSERT [dbo].[Product] ([ProductID], [SKU], [Name], [Description], [Price], [CategoryID]) VALUES (1, N'13579', N'Habitat Lawson Office Desk', N'Take a shine to Lawson with itseye catchingblack glossy looks. A compact but practicalwork stationin single pedestal style. Perfect for smaller rooms or bedrooms', CAST(55.00 AS Decimal(10, 2)), 1)
	INSERT [dbo].[Product] ([ProductID], [SKU], [Name], [Description], [Price], [CategoryID]) VALUES (2, N'21791', N'Challenge 30cm Hand Push Lawnmower', N'This lightweight and easy to push cylinder lawnmower is ideal for the smaller garden', CAST(40.00 AS Decimal(10, 2)), 2)
	INSERT [dbo].[Product] ([ProductID], [SKU], [Name], [Description], [Price], [CategoryID]) VALUES (3, N'39712', N'PlayStation 5 Console', N'Sony PlayStation 5 - Overview Play Has No Limits The PS5 console unleashes new gaming possibilities that you never anticipated', CAST(449.00 AS Decimal(10, 2)), 3)
	INSERT [dbo].[Product] ([ProductID], [SKU], [Name], [Description], [Price], [CategoryID]) VALUES (4, N'40981', N'Opti Manual Exercise Bike', N'Perfect for those who want to workout without a complicated screen or operating system this exercise bike has manual resistance and console feedback, giving you stats about your workout', CAST(79.99 AS Decimal(10, 2)), 4)
	INSERT [dbo].[Product] ([ProductID], [SKU], [Name], [Description], [Price], [CategoryID]) VALUES (5, N'58132', N'Play-Doh Large Tools and Storage', N'The reusable plastic bucket has a handle and design that is ideal for storing Play-Doh cans and more than 20 tools', CAST(20.00 AS Decimal(10, 2)), 5)

	SET IDENTITY_INSERT [dbo].[Product] OFF
END