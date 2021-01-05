namespace EcommMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class ModifiedOrderModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.Orders", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.Orders", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Orders", "Address1", c => c.String(nullable: false));
            AddColumn("dbo.Orders", "Address2", c => c.String(nullable: false));
            AddColumn("dbo.Orders", "ZipCode", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "SaveInfo", c => c.Boolean(nullable: false));
            DropColumn("dbo.Orders", "CCAddress");
            DropColumn("dbo.Orders", "CCName");
            DropColumn("dbo.Orders", "CCNumber");
            DropColumn("dbo.Orders", "CCExpiryDate");
        }

        public override void Down()
        {
            AddColumn("dbo.Orders", "CCExpiryDate", c => c.String(nullable: false));
            AddColumn("dbo.Orders", "CCNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "CCName", c => c.String());
            AddColumn("dbo.Orders", "CCAddress", c => c.String(nullable: false));
            DropColumn("dbo.Orders", "SaveInfo");
            DropColumn("dbo.Orders", "ZipCode");
            DropColumn("dbo.Orders", "Address2");
            DropColumn("dbo.Orders", "Address1");
            DropColumn("dbo.Orders", "Email");
            DropColumn("dbo.Orders", "LastName");
            DropColumn("dbo.Orders", "FirstName");
        }
    }
}
