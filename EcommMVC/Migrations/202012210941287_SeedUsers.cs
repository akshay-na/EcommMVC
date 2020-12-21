namespace EcommMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            
            
            Sql(@"

                INSERT INTO [dbo].[AspNetUsers] ([Id], [Hometown], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2b988239-34c3-4e17-845c-e60d9fe0aec7', N'XXXXX', N'akshayna04698@gmail.com', 0, N'AHxgqgGa9dm4xTBMHzZ/CPXmzhdzrERsJ0ofUb8oqGhWGUM9ZJUrGGIjypRzXh0PUw==', N'2f22728c-e71f-412f-8f16-ac0e6d32d331', NULL, 0, 0, NULL, 1, 0, N'akshayna04698@gmail.com');
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Hometown], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ab88e6a7-fc8c-4dc6-8e7e-14686462b161', N'XXXXX', N'saiprasanna@gmail.com', 0, N'AK+ctfZIFTu6BV3oeYBcMf/iergSyhff0AwMQhiiRjUYDuPhqooDKJANDzjynQxyTA==', N'50f25098-5693-41c2-a7c2-33d2f4987c9e', NULL, 0, 0, NULL, 1, 0, N'saiprasanna@gmail.com');
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Hometown], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1e335b8b-65b6-4305-a8b7-8ecb1d0a3028', N'XXXXX', N'yashwanthg@gmail.com', 0, N'AHoSEJeCeE4Z5gwgbuygcuGOxRv0xx7/hbONbSZ+8boZ3iH1szDxZwMtnz7/vpa+FA==', N'e487de6a-37b1-4384-9972-19259090d96e', NULL, 0, 0, NULL, 1, 0, N'yashwanthg@gmail.com');

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3d653914-5e7a-4540-8b07-b1867dd25256', N'Customer');
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3624ff9f-974d-44ab-988f-06f23f748575', N'Vendor');

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2b988239-34c3-4e17-845c-e60d9fe0aec7', N'3624ff9f-974d-44ab-988f-06f23f748575');
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ab88e6a7-fc8c-4dc6-8e7e-14686462b161', N'3d653914-5e7a-4540-8b07-b1867dd25256');
               
                ");
        }
        
        public override void Down()
        {
        }
    }
}
