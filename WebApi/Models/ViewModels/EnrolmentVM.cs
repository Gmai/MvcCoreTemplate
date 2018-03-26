using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.ViewModels
{
	public class EnrolmentVM
	{
		public int Id { get; set; }
		public string Drug { get; set; }
		public PatientVM Patient { get; set; }
		public GymUserVM Prescriber { get; set; }
		public ClinicVM Clinic { get; set; }
	}
}
