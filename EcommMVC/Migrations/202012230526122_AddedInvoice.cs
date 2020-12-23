namespace EcommMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedInvoice : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.OrderDetails");
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceId = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        OrderedOn = c.DateTime(nullable: false),
                        TotalAmount = c.Double(nullable: false),
                        order_OrderId = c.Long(),
                    })
                .PrimaryKey(t => t.InvoiceId)
                .ForeignKey("dbo.Orders", t => t.order_OrderId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.order_OrderId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Long(nullable: false, identity: true),
                        UserId = c.String(),
                        CCAddress = c.String(),
                        CCName = c.String(),
                        CCNumber = c.Int(nullable: false),
                        CCExpiryDate = c.String(),
                    })
                .PrimaryKey(t => t.OrderId);

            DropColumn("dbo.OrderDetails", "OrderId");
            AddColumn("dbo.OrderDetails", "Id", c => c.Long(nullable: false, identity: true));
            AddColumn("dbo.OrderDetails", "e", c => c.Long(nullable: false));
            AddPrimaryKey("dbo.OrderDetails", "Id");
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderDetails", "OrderId", c => c.Long(nullable: false, identity: true));
            DropForeignKey("dbo.Invoices", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Invoices", "order_OrderId", "dbo.Orders");
            DropIndex("dbo.Invoices", new[] { "order_OrderId" });
            DropIndex("dbo.Invoices", new[] { "UserId" });
            DropPrimaryKey("dbo.OrderDetails");
            DropColumn("dbo.OrderDetails", "e");
            DropColumn("dbo.OrderDetails", "Id");
            DropTable("dbo.Orders");
            DropTable("dbo.Invoices");
            AddPrimaryKey("dbo.OrderDetails", "OrderId");
        }
    }
}
