namespace DojoLoko.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teste123 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Aulas", "Data", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Aulas", "Data", c => c.DateTime(nullable: false));
        }
    }
}
