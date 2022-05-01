namespace GCE.Domain.Migrations
{
    using GCE.Domain.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<UpCardapio.Domain.GceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(UpCardapio.Domain.GceContext dbo)
        {
            var pessoa1 = new Pessoa()
            {
                TipoPessoa = TipoPessoa.Juridica,
                Nacional = Nacional.Sim,
                Situacao = Situacao.Elaboracao,
                Cnpj = "01.571.702/001-98",
                Nome = "HALEX ISTAR IND FARMACEUTICA LTDA",
                NomeFantasia = "HALEX ISTAR IND FARMACEUTICA LTDA",
                TipoEmpresa = TipoEmpresa.Ltda,
                Porte = Porte.Outros,
                Fone1 = "(51) 3366-3806",
                Email = "contato@gmail.com",
                CaptalSocial = Convert.ToDecimal(82500000.00),
                CreatedBy = "Gce"                
            };

            dbo.Pessoas.AddOrUpdate(m => new { m.Nome, m.CreatedBy }, pessoa1);

            var pessoa2 = new Pessoa()
            {
                TipoPessoa = TipoPessoa.Juridica,
                Nacional = Nacional.Sim,
                Situacao = Situacao.Elaboracao,
                Cnpj = "02.571.702/001-98",
                Nome = "HALEX COPY",
                NomeFantasia = "HALEX COPY",
                TipoEmpresa = TipoEmpresa.Ltda,
                Porte = Porte.Outros,
                Fone1 = "(51) 3366-3806",
                Email = "contato@gmail.com",
                CaptalSocial = Convert.ToDecimal(82500000.00),
                CreatedBy = "Gce"
            };

            dbo.Pessoas.AddOrUpdate(m => new { m.Nome, m.CreatedBy }, pessoa2);

            var pessoa3 = new Pessoa()
            {
                TipoPessoa = TipoPessoa.Fisica,
                Nacional = Nacional.Sim,
                Situacao = Situacao.Elaboracao,
                Cpf = "976.729.710-34",
                Nome = "CAMILA LAIS CARGNELUTTI",
                TipoEmpresa = TipoEmpresa.Leiloeiro,
                Genero = Genero.Feminino,
                Fone1 = "(55) 3332-8613",
                Email = "contato@gmail.com",
                DataNascimento = Convert.ToDateTime("1979-12-12"),
                Nacionalidade = "Brasileira",
                Profissao = "Não Informado",
                CreatedBy = "Gce"
            };

            dbo.Pessoas.AddOrUpdate(m => new { m.Nome, m.CreatedBy }, pessoa3);

            var pessoa4 = new Pessoa()
            {
                TipoPessoa = TipoPessoa.Fisica,
                Nacional = Nacional.Sim,
                Situacao = Situacao.Elaboracao,
                Cpf = "977.729.710-34",
                Nome = "CAMILA COPY II",
                TipoEmpresa = TipoEmpresa.Leiloeiro,
                Genero = Genero.Feminino,
                Fone1 = "(55) 3332-8613",
                Email = "contato@gmail.com",
                DataNascimento = Convert.ToDateTime("1979-12-12"),
                Nacionalidade = "Brasileira",
                Profissao = "Não Informado",
                CreatedBy = "Gce"
            };

            dbo.Pessoas.AddOrUpdate(m => new { m.Nome, m.CreatedBy }, pessoa4);

            dbo.SaveChanges();
        }
    }
}
