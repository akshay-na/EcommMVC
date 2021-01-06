namespace EcommMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class ModifiedOrderModel1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Orders");
            AddPrimaryKey("dbo.Orders", "OrderId");
            DropColumn("dbo.Orders", "Id");
        }

        public override void Down()
        {
            AddColumn("dbo.Orders", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Orders");
            AddPrimaryKey("dbo.Orders", "Id");
        }
    }
}
