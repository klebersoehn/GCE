using GCE.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gce.Domain.Models
{
    public partial class Pessoa : BaseEntity, IValidatableObject
    {
        [Key]
        public int Id { get; set; }

        //Quando CNPJ é Razão Social
        [Required]
        [StringLength(120)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [StringLength(120)]
        [Display(Name = "Nome Fantasia")]
        public string NomeFantasia { get; set; }

        [StringLength(25)]
        public string Cpf { get; set; }

        [StringLength(25)]
        public string Cnpj { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data Nascimento")]
        public DateTime? DataNascimento { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data da Constituição")]
        public DateTime? DataConstituicao { get; set; }

        [Required]
        [StringLength(20)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Fone 1")]
        public string Fone1 { get; set; }

        [StringLength(20)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Fone 2")]
        public string Fone2 { get; set; }

        [StringLength(20)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Fone 3")]
        public string Fone3 { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Display(Name = "Website")]
        [StringLength(200)]
        public string WebSite { get; set; }

        [Display(Name = "Profissão")]
        [StringLength(200)]
        public string Profissao { get; set; }

        [Display(Name = "Nacionalidade")]
        [StringLength(100)]
        public string Nacionalidade { get; set; }

        [Display(Name = "Quantidade de Quota")]
        public int? QuantidadeQuota { get; set; }

        [DataType(DataType.Currency)]
        public decimal? ValorQuota { get; set; }

        [Display(Name = "Capital Social")]
        [DataType(DataType.Currency)]
        public decimal CaptalSocial { get; set; }

        [Display(Name = "Tipo de Pessoa")]
        public TipoPessoa TipoPessoa { get; set; }

        [Display(Name = "Tipo de Empresa")]
        public TipoEmpresa TipoEmpresa { get; set; }

        public Porte Porte { get; set; }

        [Required]
        public Nacional Nacional { get; set; }

        [Display(Name = "Gênero")]
        public Genero Genero { get; set; }

        [Display(Name = "Situação")]
        public Situacao Situacao { get; set; }

        [Display(Name = "Estado Civil")]
        public EstadoCivil EstadoCivil { get; set; }

        [Display(Name = "Caracterização do Capital")]
        public CaracterizacaoCaptal CaracterizacaoCaptal { get; set; }


        public Pessoa()
        {

        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (TipoPessoa == TipoPessoa.Juridica)
            {
                if (string.IsNullOrEmpty(Cnpj))
                {
                    yield return new ValidationResult(string.Format("O campo {0} é obrigatório.", "Cnpj"), new[] { nameof(Cnpj) });
                }

                if (TipoEmpresa == 0)
                {
                    yield return new ValidationResult(string.Format("O campo {0} é obrigatório.", "TipoEmpresa"), new[] { nameof(TipoEmpresa) });
                }

                if (Porte == 0)
                {
                    yield return new ValidationResult(string.Format("O campo {0} é obrigatório.", "Porte"), new[] { nameof(Porte) });
                }

                if (CaptalSocial < 0)
                {
                    yield return new ValidationResult(string.Format("O campo {0} é obrigatório.", "CaptalSocial"), new[] { nameof(CaptalSocial) });
                }
            }
            else
            {
                if (string.IsNullOrEmpty(Cpf))
                {
                    yield return new ValidationResult(string.Format("O campo {0} é obrigatório.", "Cpf"), new[] { nameof(Cpf) });
                }
                if (string.IsNullOrEmpty(Profissao))
                {
                    yield return new ValidationResult(string.Format("O campo {0} é obrigatório.", "Profissao"), new[] { nameof(Profissao) });
                }
                if (TipoEmpresa == 0)
                {
                    yield return new ValidationResult(string.Format("O campo {0} é obrigatório.", "TipoEmpresa"), new[] { nameof(TipoEmpresa) });
                }
                if (!DataNascimento.HasValue)
                {
                    yield return new ValidationResult(string.Format("O campo {0} é obrigatório.", "DataNascimento"), new[] { nameof(DataNascimento) });
                }
                if (Genero == 0)
                {
                    yield return new ValidationResult(string.Format("O campo {0} é obrigatório.", "Genero"), new[] { nameof(Genero) });
                }
            }
        }
    }
}
