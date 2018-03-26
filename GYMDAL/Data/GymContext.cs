using GYMDAL.DAO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYMDAL.Data
{
    public class GymContext : DbContext
	{
		public GymContext(DbContextOptions<GymContext> options) : base(options)
		{
		}

		public DbSet<Role> Roles { get; set; }
		public DbSet<GymUser> Users { get; set; }
		public DbSet<UserRole> UserRoles { get; set; }
		public DbSet<Patient> Patients { get; set; }
		public DbSet<Clinic> Clinics { get; set; }
		public DbSet<Enrolment> Enrolments { get; set; }
	}
}
