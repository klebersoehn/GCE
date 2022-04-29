using System.ComponentModel.DataAnnotations;

namespace GCE.Domain.Models
{
    public enum Situacao
    {
        [Display(Name = "Ativo")]
        Ativo = 1,

        [Display(Name = "Inativo")]
        Inativo = 2
    }

    public enum Nacional
    {
        [Display(Name = "Sim")]
        Sim = 1,

        [Display(Name = "Não")]
        Nao = 2
    }

    public enum TipoPessoa
    {
        [Display(Name = "Física")]
        Fisica = 1,

        [Display(Name = "Jurídica")]
        Juridica = 2
    }

    public enum TipoEmpresa
    {
        [Display(Name = "Ltda")]
        Ltda = 1,

        [Display(Name = "Me")]
        Me = 2
    }

    public enum Porte
    {
        [Display(Name = "Outros")]
        Outros = 1
    }

    public enum CaracterizacaoCaptal
    {
        [Display(Name = "Outros")]
        Outros = 1
    }

    public enum EstadoCivil
    {
        [Display(Name = "Solteiro")]
        Solteiro = 1,

        [Display(Name = "Casado")]
        Casado = 2
    }

    public enum Genero
    {
        [Display(Name = "Feminino")]
        Feminino = 1,

        [Display(Name = "Masculino")]
        Masculino = 2
    }
}