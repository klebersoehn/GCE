namespace GCE.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editPessoa : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pessoa", "CaptalSocial", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pessoa", "CaptalSocial", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
