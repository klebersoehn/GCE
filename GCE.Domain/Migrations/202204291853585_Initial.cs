namespace GCE.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pessoa",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 120),
                        NomeFantasia = c.String(maxLength: 120),
                        Cpf = c.String(maxLength: 25),
                        Cnpj = c.String(maxLength: 25),
                        DataNascimento = c.DateTime(),
                        DataConstituicao = c.DateTime(),
                        Fone1 = c.String(nullable: false, maxLength: 20),
                        Fone2 = c.String(maxLength: 20),
                        Fone3 = c.String(maxLength: 20),
                        Email = c.String(nullable: false, maxLength: 100),
                        WebSite = c.String(maxLength: 200),
                        Profissao = c.String(maxLength: 200),
                        Nacionalidade = c.String(maxLength: 100),
                        QuantidadeQuota = c.Int(),
                        ValorQuota = c.Decimal(precision: 18, scale: 2),
                        CaptalSocial = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TipoPessoa = c.Int(nullable: false),
                        TipoEmpresa = c.Int(nullable: false),
                        Porte = c.Int(nullable: false),
                        Nacional = c.Int(nullable: false),
                        Genero = c.Int(nullable: false),
                        Situacao = c.Int(nullable: false),
                        EstadoCivil = c.Int(nullable: false),
                        CaracterizacaoCaptal = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(),
                        UpdatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pessoa");
        }
    }
}
