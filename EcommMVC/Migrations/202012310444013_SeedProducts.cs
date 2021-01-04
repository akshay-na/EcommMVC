namespace EcommMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedProducts : DbMigration
    {
        public override void Up()
        {

            Sql(@"

                INSERT INTO [dbo].[ProductDetails] ([ProductId], [VendorId], [ProductName], [ProductQuantity], [ProductPrice], [ProductCategory], [ProductPicPath]) VALUES (1, N'2b988239-34c3-4e17-845c-e60d9fe0aec7', N'OnePlus 5', 100, 32999, N'Mobile', N'http://127.0.0.1:8887/Products/1.jpg')
                INSERT INTO [dbo].[ProductDetails] ([ProductId], [VendorId], [ProductName], [ProductQuantity], [ProductPrice], [ProductCategory], [ProductPicPath]) VALUES (2, N'2b988239-34c3-4e17-845c-e60d9fe0aec7', N'ASUS Laptop', 50, 49999, N'Laptop', N'http://127.0.0.1:8887/Products/2.jpg')
                INSERT INTO [dbo].[ProductDetails] ([ProductId], [VendorId], [ProductName], [ProductQuantity], [ProductPrice], [ProductCategory], [ProductPicPath]) VALUES (3, N'2b988239-34c3-4e17-845c-e60d9fe0aec7', N'Sony Headphones', 200, 4999, N'Mobile Accessories', N'http://127.0.0.1:8887/Products/3.jpg')
                INSERT INTO [dbo].[ProductDetails] ([ProductId], [VendorId], [ProductName], [ProductQuantity], [ProductPrice], [ProductCategory], [ProductPicPath]) VALUES (4, N'2b988239-34c3-4e17-845c-e60d9fe0aec7', N'Apple Watch Series 6', 20, 39999, N'Watch', N'http://127.0.0.1:8887/Products/4.jpg')
                INSERT INTO [dbo].[ProductDetails] ([ProductId], [VendorId], [ProductName], [ProductQuantity], [ProductPrice], [ProductCategory], [ProductPicPath]) VALUES (5, N'2b988239-34c3-4e17-845c-e60d9fe0aec7', N'iPhone 12', 200, 69999, N'Mobile', N'http://127.0.0.1:8887/Products/5.jpg')
                INSERT INTO [dbo].[ProductDetails] ([ProductId], [VendorId], [ProductName], [ProductQuantity], [ProductPrice], [ProductCategory], [ProductPicPath]) VALUES (6, N'2b988239-34c3-4e17-845c-e60d9fe0aec7', N'OnePlus Y-series TV 32', 100, 13999, N'TV', N'http://127.0.0.1:8887/Products/6.jpg')
                INSERT INTO [dbo].[ProductDetails] ([ProductId], [VendorId], [ProductName], [ProductQuantity], [ProductPrice], [ProductCategory], [ProductPicPath]) VALUES (7, N'2b988239-34c3-4e17-845c-e60d9fe0aec7', N'Gaming PC with RTX 3090', 10, 105999, N'GPU', N'http://127.0.0.1:8887/Products/7.jpg')

            ");
        }

        public override void Down()
        {
        }
    }
}
