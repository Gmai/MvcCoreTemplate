using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GYMDAL.DAO
{
	[Table("Enrolments")]
	public class Enrolment
	{
		[Key, Required]
		public int Id { get; set; }

		[Required]
		public string Drug { get; set; }

		public Patient Patient { get; set; }
		public GymUser Prescriber { get; set; }
		public Clinic Clinic { get; set; }
	}
}
