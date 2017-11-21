namespace DojoLoko.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Bagulhodavalidação2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Alunoes", "Nome", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Alunoes", "CPF", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Alunoes", "CPF", c => c.String(nullable: false));
            AlterColumn("dbo.Alunoes", "Nome", c => c.String(nullable: false));
        }
    }
}
