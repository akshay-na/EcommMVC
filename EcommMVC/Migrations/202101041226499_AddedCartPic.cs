namespace EcommMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddedCartPic : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "ItemPicPath", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.Carts", "ItemPicPath");
        }
    }
}
