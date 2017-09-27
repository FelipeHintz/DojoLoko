namespace DojoLoko.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class corrigindoOsParanaue : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Alunos", "Faixa_ID", "dbo.Faixas");
            DropForeignKey("dbo.Alunos", "TipoDeAssociacao_ID", "dbo.TipoDeAssociacaos");
            DropIndex("dbo.Alunos", new[] { "Faixa_ID" });
            DropIndex("dbo.Alunos", new[] { "TipoDeAssociacao_ID" });
            RenameColumn(table: "dbo.Alunos", name: "Faixa_ID", newName: "FaixaId");
            RenameColumn(table: "dbo.Alunos", name: "TipoDeAssociacao_ID", newName: "TipodeAssociacaoId");
            AlterColumn("dbo.Alunos", "FaixaId", c => c.Int(nullable: false));
            AlterColumn("dbo.Alunos", "TipodeAssociacaoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Alunos", "FaixaId");
            CreateIndex("dbo.Alunos", "TipodeAssociacaoId");
            AddForeignKey("dbo.Alunos", "FaixaId", "dbo.Faixas", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Alunos", "TipodeAssociacaoId", "dbo.TipoDeAssociacaos", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Alunos", "TipodeAssociacaoId", "dbo.TipoDeAssociacaos");
            DropForeignKey("dbo.Alunos", "FaixaId", "dbo.Faixas");
            DropIndex("dbo.Alunos", new[] { "TipodeAssociacaoId" });
            DropIndex("dbo.Alunos", new[] { "FaixaId" });
            AlterColumn("dbo.Alunos", "TipodeAssociacaoId", c => c.Int());
            AlterColumn("dbo.Alunos", "FaixaId", c => c.Int());
            RenameColumn(table: "dbo.Alunos", name: "TipodeAssociacaoId", newName: "TipoDeAssociacao_ID");
            RenameColumn(table: "dbo.Alunos", name: "FaixaId", newName: "Faixa_ID");
            CreateIndex("dbo.Alunos", "TipoDeAssociacao_ID");
            CreateIndex("dbo.Alunos", "Faixa_ID");
            AddForeignKey("dbo.Alunos", "TipoDeAssociacao_ID", "dbo.TipoDeAssociacaos", "ID");
            AddForeignKey("dbo.Alunos", "Faixa_ID", "dbo.Faixas", "ID");
        }
    }
}
