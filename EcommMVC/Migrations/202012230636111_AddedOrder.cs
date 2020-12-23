namespace EcommMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "OrderId", c => c.Long(nullable: false));
            CreateIndex("dbo.OrderDetails", "OrderId");
            AddForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders", "OrderId", cascadeDelete: true);
            DropColumn("dbo.OrderDetails", "e");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderDetails", "e", c => c.Long(nullable: false));
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropColumn("dbo.OrderDetails", "OrderId");
        }
    }
}
