namespace EcommMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedProducts : DbMigration
    {
        public override void Up()
        {

            Sql(@"

                INSERT INTO [dbo].[ProductDetails] ([ProductId], [VendorId], [ProductName], [ProductQuantity], [ProductPrice], [ProductCategory], [ProductPicPath], [ShortDiscription]) VALUES (1, N'2b988239-34c3-4e17-845c-e60d9fe0aec7', N'OnePlus 5', 100, 32999, N'Mobile', N'http://127.0.0.1:8887/Products/1.jpg', N'(Slate Gray 6GB RAM + 64GB memory)')
                INSERT INTO [dbo].[ProductDetails] ([ProductId], [VendorId], [ProductName], [ProductQuantity], [ProductPrice], [ProductCategory], [ProductPicPath], [ShortDiscription]) VALUES (2, N'2b988239-34c3-4e17-845c-e60d9fe0aec7', N'ASUS ZenBook 13 UX334FL-A5821TS Intel Core i5 10th Gen 13.3-inch FHD Thin & Light Laptop (8GB RAM/512GB PCIe SSD/Windows 1...
                ASUS ZenBook 13 UX334FL-A5821TS', 50, 49999, N'Laptop', N'http://127.0.0.1:8887/Products/2.jpg', N'NULL')
                INSERT INTO [dbo].[ProductDetails] ([ProductId], [VendorId], [ProductName], [ProductQuantity], [ProductPrice], [ProductCategory], [ProductPicPath], [ShortDiscription]) VALUES (3, N'2b988239-34c3-4e17-845c-e60d9fe0aec7', N'Sony MDR-XB450', 200, 4999, N'Mobile Accessories', N'http://127.0.0.1:8887/Products/3.jpg', N'On-Ear EXTRA BASS Headphones (Black)')
                INSERT INTO [dbo].[ProductDetails] ([ProductId], [VendorId], [ProductName], [ProductQuantity], [ProductPrice], [ProductCategory], [ProductPicPath], [ShortDiscription]) VALUES (4, N'2b988239-34c3-4e17-845c-e60d9fe0aec7', N'Apple Watch Series 6', 20, 39999, N'Watch', N'http://127.0.0.1:8887/Products/4.jpg', N'(GPS + Cellular, 44mm) -  Aluminium Case with Product - Sport Band')
                INSERT INTO [dbo].[ProductDetails] ([ProductId], [VendorId], [ProductName], [ProductQuantity], [ProductPrice], [ProductCategory], [ProductPicPath], [ShortDiscription]) VALUES (5, N'2b988239-34c3-4e17-845c-e60d9fe0aec7', N'Apple iPhone 12', 200, 69999, N'Mobile', N'http://127.0.0.1:8887/Products/5.jpg', N'(128GB) - Black')
                INSERT INTO [dbo].[ProductDetails] ([ProductId], [VendorId], [ProductName], [ProductQuantity], [ProductPrice], [ProductCategory], [ProductPicPath], [ShortDiscription]) VALUES (6, N'2b988239-34c3-4e17-845c-e60d9fe0aec7', N'OnePlus Y Series', 100, 13999, N'TV', N'http://127.0.0.1:8887/Products/6.jpg', N'80 cm (32 inches) HD Ready LED Smart Android TV 32Y1 (Black) (2020 Model)')
                INSERT INTO [dbo].[ProductDetails] ([ProductId], [VendorId], [ProductName], [ProductQuantity], [ProductPrice], [ProductCategory], [ProductPicPath], [ShortDiscription]) VALUES (7, N'2b988239-34c3-4e17-845c-e60d9fe0aec7', N'Gigabyte Nvidia GeForce RTX 3090', 10, 105999, N'GPU', N'http://127.0.0.1:8887/Products/7.jpg', N'AORUS Master 24GB GDDR6X Graphics Card (GV-N3090AORUS M-24GD)')


            ");
        }

        public override void Down()
        {
        }
    }
}
