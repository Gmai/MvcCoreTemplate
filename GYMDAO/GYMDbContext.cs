using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MvcCore.Models;
using WebApi.Models.Identity;

namespace WebApi.Data
{
    public class GYMDbContext : IdentityDbContext<IdentityUser>
    {
        public GYMDbContext(DbContextOptions<IdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }

    ///// <summary>
    ///// Base class for the Entity Framework database context used for identity.
    ///// </summary>
    ///// <typeparam name="TUser">The type of user objects.</typeparam>
    ///// <typeparam name="TRole">The type of role objects.</typeparam>
    ///// <typeparam name="TKey">The type of the primary key for users and roles.</typeparam>
    ///// <typeparam name="TUserClaim">The type of the user claim object.</typeparam>
    ///// <typeparam name="TUserRole">The type of the user role object.</typeparam>
    ///// <typeparam name="TUserLogin">The type of the user login object.</typeparam>
    ///// <typeparam name="TRoleClaim">The type of the role claim object.</typeparam>
    ///// <typeparam name="TUserToken">The type of the user token object.</typeparam>
    //public abstract class IdentityDbContext<TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken> : IdentityUserContext<TUser, TKey, TUserClaim, TUserLogin, TUserToken>
    //    where TUser : IdentityUser<TKey>
    //    where TRole : IdentityRole<TKey>
    //    where TKey : IEquatable<TKey>
    //    where TUserClaim : IdentityUserClaim<TKey>
    //    where TUserRole : IdentityUserRole<TKey>
    //    where TUserLogin : IdentityUserLogin<TKey>
    //    where TRoleClaim : IdentityRoleClaim<TKey>
    //    where TUserToken : IdentityUserToken<TKey>
    //{
    //    /// <summary>
    //    /// Initializes a new instance of the class.
    //    /// </summary>
    //    /// <param name="options">The options to be used by a <see cref="DbContext"/>.</param>
    //    public IdentityDbContext(DbContextOptions options) : base(options) { }

    //    /// <summary>
    //    /// Initializes a new instance of the class.
    //    /// </summary>
    //    protected IdentityDbContext() { }

    //    /// <summary>
    //    /// Gets or sets the <see cref="DbSet{TEntity}"/> of User roles.
    //    /// </summary>
    //    public DbSet<TUserRole> UserRoles { get; set; }

    //    /// <summary>
    //    /// Gets or sets the <see cref="DbSet{TEntity}"/> of roles.
    //    /// </summary>
    //    public DbSet<TRole> Roles { get; set; }

    //    /// <summary>
    //    /// Gets or sets the <see cref="DbSet{TEntity}"/> of role claims.
    //    /// </summary>
    //    public DbSet<TRoleClaim> RoleClaims { get; set; }

    //    /// <summary>
    //    /// Configures the schema needed for the identity framework.
    //    /// </summary>
    //    /// <param name="builder">
    //    /// The builder being used to construct the model for this context.
    //    /// </param>
    //    protected override void OnModelCreating(ModelBuilder builder)
    //    {
    //        base.OnModelCreating(builder);
    //        builder.Entity<TUser>(b =>
    //        {
    //            b.HasMany<TUserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
    //        });

    //        builder.Entity<TRole>(b =>
    //        {
    //            b.HasKey(r => r.Id);
    //            b.HasIndex(r => r.NormalizedName).HasName("RoleNameIndex").IsUnique();
    //            b.ToTable("AspNetRoles");
    //            b.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();

    //            b.Property(u => u.Name).HasMaxLength(256);
    //            b.Property(u => u.NormalizedName).HasMaxLength(256);

    //            b.HasMany<TUserRole>().WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();
    //            b.HasMany<TRoleClaim>().WithOne().HasForeignKey(rc => rc.RoleId).IsRequired();
    //        });

    //        builder.Entity<TRoleClaim>(b =>
    //        {
    //            b.HasKey(rc => rc.Id);
    //            b.ToTable("AspNetRoleClaims");
    //        });

    //        builder.Entity<TUserRole>(b =>
    //        {
    //            b.HasKey(r => new { r.UserId, r.RoleId });
    //            b.ToTable("AspNetUserRoles");
    //        });
    //    }
    //}
}
