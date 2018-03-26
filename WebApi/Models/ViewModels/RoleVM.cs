using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.ViewModels
{
	[Table("Role")]
	public class RoleVM
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public virtual ICollection<GymUserVM> Users { get; set; }
	}
}
