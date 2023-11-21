namespace PartyProductMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2d68fd41-ae00-46a9-afa3-205edcdc612b', N'admin@PartyProduct.com', 0, N'AMZJSObBrt/lU1G7HZm/4du1RnQMgwNL/BK5mafvOFfXi8HzsgIJxnCsmVuP6AvSAA==', N'50f0d942-350a-4c32-a155-1fccf8b94356', NULL, 0, 0, NULL, 1, 0, N'admin@PartyProduct.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd08ce850-4835-4317-bac9-8fd46e229236', N'yashparmar@gmail.com', 0, N'ACSK2axKSNRsUJ3rQJlnkU9Ooqpf0PIWtVoNM5Zv5RtDTRT1bEn87DpfLSyW9lliFg==', N'ae70da1d-ed13-4577-a167-7895272f3bf6', NULL, 0, 0, NULL, 1, 0, N'yashparmar@gmail.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'9f902fd0-1f17-44fb-b108-0acf0d4c5c0a', N'Admin')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2d68fd41-ae00-46a9-afa3-205edcdc612b', N'9f902fd0-1f17-44fb-b108-0acf0d4c5c0a')



");
        }

        public override void Down()
        {
        }
    }
}
