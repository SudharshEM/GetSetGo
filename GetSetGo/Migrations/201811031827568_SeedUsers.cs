namespace GetSetGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'954e5396-6930-4f1d-a341-888736aad0ac', N'guest@getsetgo.com', 0, N'AD6oUA89N5QV4jzxcgXV7nFPkZOzsvzD36N56T21mSaDcudiX112LvmUyHm19yQdKw==', N'95fcfcd0-a81c-4973-bd52-69b2c415230b', NULL, 0, 0, NULL, 1, 0, N'guest@getsetgo.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f907b5bb-32cd-45ed-899a-8fdbd2b23d49', N'admin@getsetgo.com', 0, N'ACPvkDX6ksP1ac6cmFpjEHaPIvTCkLLabrPnQoKNuxGD58/ngzCS5QS7lvZ7du+Gpw==', N'73e57522-35c1-4c9c-a1c9-ff71a17cebb8', NULL, 0, 0, NULL, 1, 0, N'admin@getsetgo.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'c0f9284c-5fb7-4b83-94d4-fcbd4d3bb1d5', N'CanManageVehicles')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f907b5bb-32cd-45ed-899a-8fdbd2b23d49', N'c0f9284c-5fb7-4b83-94d4-fcbd4d3bb1d5')
");
        }

        public override void Down()
        {
        }
    }
}
