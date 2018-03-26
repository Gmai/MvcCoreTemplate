using CrossCutting.DataAnnotations;
using CrossCutting.Enums;
using CrossCutting.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.ViewModels
{
	[Table("Patients")]
	public class PatientVM
	{
		[Field(label: "Patient ID", required: true)]
		public int Id { get; set; } 
		[Field(label:"Patient Name",required:true)]
		public string Name { get; set; }
		[Field(label: "Email Address", required: true,type:FieldType.EMAIL)]
		public string Email { get; set; }
	}
}
