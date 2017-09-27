namespace DojoLoko.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correcaoNomeTabela : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Alunoes", newName: "Alunos");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Alunos", newName: "Alunoes");
        }
    }
}
