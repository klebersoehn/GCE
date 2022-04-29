using GCE.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gce.Domain.Models
{
    public partial class Pessoa : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(120)]
        //[Display(Name = "Nome", ResourceType = typeof(Resources.Models.Pessoa))]
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

        [StringLength(20)]
        [DataType(DataType.PhoneNumber)]
        //[Display(Name = "Fone1", ResourceType = typeof(Resources.Models.Pessoa))]
        public string Fone1 { get; set; }

        [StringLength(20)]
        [DataType(DataType.PhoneNumber)]
        //[Display(Name = "Fone2", ResourceType = typeof(Resources.Models.Pessoa))]
        public string Fone2 { get; set; }

        [StringLength(20)]
        [DataType(DataType.PhoneNumber)]
        //[Display(Name = "Fone2", ResourceType = typeof(Resources.Models.Pessoa))]
        public string Fone3 { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        [EmailAddress]
        [Index(IsUnique = true)]
        [StringLength(100)]
        public string Email { get; set; }

        public int? QuantidadeQuota { get; set; }

        [DataType(DataType.Currency)]
        public decimal? ValorQuota { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal CaptalInicial { get; set; }

        [Required]
        [StringLength(1)]
        //[Display(Name = "Tipo", ResourceType = typeof(Resources.Models.Pessoa))]
        public TipoPessoa TipoPessoa { get; set; }

        [Required]
        public Nacional Nacional { get; set; }

        public Situacao Situacao { get; set; }


        public Pessoa()
        {

        }

    }
}
