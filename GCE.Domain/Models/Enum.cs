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
}