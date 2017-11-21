namespace DojoLoko.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Bagulhodavalidação : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Alunos", newName: "Alunoes");
            AlterColumn("dbo.Alunoes", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.Alunoes", "CPF", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Alunoes", "CPF", c => c.String());
            AlterColumn("dbo.Alunoes", "Nome", c => c.String());
            RenameTable(name: "dbo.Alunoes", newName: "Alunos");
        }
    }
}
