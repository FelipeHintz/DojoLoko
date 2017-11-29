namespace DojoLoko.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [PasswordHash], [SecurityStamp], [Discriminator]) VALUES (N'711b50db-5230-4b67-ad61-c1f9e92234e4', N'teste1', N'AGHa6q0jyOGOx0nV319SvSz7rnSz9v3b7VBEJ/j8jt5NaZPuv4f/5TOP25eeGcuTVw==', N'8ddbf498-4c3e-4b2b-a3ae-2f93f8002ea6', N'ApplicationUser')");
        }
        
        public override void Down()
        {

        }
    }
}
