namespace DojoLoko.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correcaoNomeTabela1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Alunos", newName: "Alunoes");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Alunoes", newName: "Alunos");
        }
    }
}
