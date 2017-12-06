namespace DojoLoko.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teste : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AulaAlunoes",
                c => new
                    {
                        Aula_ID = c.Int(nullable: false),
                        Aluno_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Aula_ID, t.Aluno_ID })
                .ForeignKey("dbo.Aulas", t => t.Aula_ID, cascadeDelete: true)
                .ForeignKey("dbo.Alunoes", t => t.Aluno_ID, cascadeDelete: true)
                .Index(t => t.Aula_ID)
                .Index(t => t.Aluno_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AulaAlunoes", "Aluno_ID", "dbo.Alunoes");
            DropForeignKey("dbo.AulaAlunoes", "Aula_ID", "dbo.Aulas");
            DropIndex("dbo.AulaAlunoes", new[] { "Aluno_ID" });
            DropIndex("dbo.AulaAlunoes", new[] { "Aula_ID" });
            DropTable("dbo.AulaAlunoes");
        }
    }
}
