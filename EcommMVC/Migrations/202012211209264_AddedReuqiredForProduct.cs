namespace EcommMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedReuqiredForProduct : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductDetails", "ProductName", c => c.String(nullable: false));
            AlterColumn("dbo.ProductDetails", "ProductCategory", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductDetails", "ProductCategory", c => c.String());
            AlterColumn("dbo.ProductDetails", "ProductName", c => c.String());
        }
    }
}
