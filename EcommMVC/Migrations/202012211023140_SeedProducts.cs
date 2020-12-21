namespace EcommMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedProducts : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ProductDetails(VendorId, ProductName, ProductPrice, ProductQuantity,  ProductCategory) VALUES (N'2b988239-34c3-4e17-845c-e60d9fe0aec7', 'OnePlus 5', 32999, 100, 'Mobile')");
            Sql("INSERT INTO ProductDetails(VendorId, ProductName, ProductPrice, ProductQuantity,  ProductCategory) VALUES (N'2b988239-34c3-4e17-845c-e60d9fe0aec7', 'ASUS Laptop', 49999, 50, 'Laptop')");
            Sql("INSERT INTO ProductDetails(VendorId, ProductName, ProductPrice, ProductQuantity,  ProductCategory) VALUES (N'2b988239-34c3-4e17-845c-e60d9fe0aec7', 'Sony Headphones', 4999, 200, 'Mobile Accessories')");
            Sql("INSERT INTO ProductDetails(VendorId, ProductName, ProductPrice, ProductQuantity,  ProductCategory) VALUES (N'2b988239-34c3-4e17-845c-e60d9fe0aec7', 'Apple Watch Series 6', 39999, 20, 'Watch')");
            Sql("INSERT INTO ProductDetails(VendorId, ProductName, ProductPrice, ProductQuantity,  ProductCategory) VALUES (N'2b988239-34c3-4e17-845c-e60d9fe0aec7', 'iPhone 12', 69999, 200, 'Mobile')");
            Sql("INSERT INTO ProductDetails(VendorId, ProductName, ProductPrice, ProductQuantity,  ProductCategory) VALUES (N'2b988239-34c3-4e17-845c-e60d9fe0aec7', 'OnePlus Y-series TV 32', 13999, 100, 'TV')");
            Sql("INSERT INTO ProductDetails(VendorId, ProductName, ProductPrice, ProductQuantity,  ProductCategory) VALUES (N'2b988239-34c3-4e17-845c-e60d9fe0aec7', 'Gaming PC with RTX 3090', 105999, 10, 'GPU')");
        }

        public override void Down()
        {
        }
    }
}
