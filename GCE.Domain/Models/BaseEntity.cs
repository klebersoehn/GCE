using System;
using System.ComponentModel.DataAnnotations;

namespace GCE.Domain.Models
{
    public abstract class BaseEntity
	{
        [ScaffoldColumn(false)]
		public string CreatedBy { get; set; }

		[DataType(DataType.Date)]
		[ScaffoldColumn(false)]
		public DateTime? CreatedDate { get; set; }

		[ScaffoldColumn(false)]
		public string UpdatedBy { get; set; }

		[DataType(DataType.Date)]
		[ScaffoldColumn(false)]
		public DateTime? UpdatedDate { get; set; }
    }
}
