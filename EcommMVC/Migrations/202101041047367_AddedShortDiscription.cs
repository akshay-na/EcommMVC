namespace EcommMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddedShortDiscription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductDetails", "ShortDiscription", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.ProductDetails", "ShortDiscription");
        }
    }
}
