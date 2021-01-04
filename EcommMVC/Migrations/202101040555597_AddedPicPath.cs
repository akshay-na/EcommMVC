namespace EcommMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPicPath : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductDetails", "ProductPicPath", c => c.String());
            AddColumn("dbo.AspNetUsers", "ProfilePicPath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ProfilePicPath");
            DropColumn("dbo.ProductDetails", "ProductPicPath");
        }
    }
}
