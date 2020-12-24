namespace EcommMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedOrderModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Invoices", "order_OrderId", "dbo.Orders");
            DropIndex("dbo.Invoices", new[] { "order_OrderId" });
            RenameColumn(table: "dbo.Invoices", name: "order_OrderId", newName: "OrderId");
            AlterColumn("dbo.Invoices", "OrderId", c => c.Long(nullable: false));
            AlterColumn("dbo.Orders", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Orders", "CCAddress", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "CCExpiryDate", c => c.String(nullable: false));
            CreateIndex("dbo.Invoices", "OrderId");
            CreateIndex("dbo.Orders", "UserId");
            AddForeignKey("dbo.Orders", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Invoices", "OrderId", "dbo.Orders", "OrderId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoices", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.Invoices", new[] { "OrderId" });
            AlterColumn("dbo.Orders", "CCExpiryDate", c => c.String());
            AlterColumn("dbo.Orders", "CCAddress", c => c.String());
            AlterColumn("dbo.Orders", "UserId", c => c.String());
            AlterColumn("dbo.Invoices", "OrderId", c => c.Long());
            RenameColumn(table: "dbo.Invoices", name: "OrderId", newName: "order_OrderId");
            CreateIndex("dbo.Invoices", "order_OrderId");
            AddForeignKey("dbo.Invoices", "order_OrderId", "dbo.Orders", "OrderId");
        }
    }
}
