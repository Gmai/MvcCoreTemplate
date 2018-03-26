using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GYMDAL.DAO
{
	[Table("Clinics")]
	public class Clinic
	{
		[Key, Required]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

	}
}
