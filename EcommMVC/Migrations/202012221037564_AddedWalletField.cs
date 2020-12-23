namespace EcommMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedWalletField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Wallet", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Wallet");
        }
    }
}
