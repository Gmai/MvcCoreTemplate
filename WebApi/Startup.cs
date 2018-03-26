using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GYMDAL.Data;
using WebApi.Models;
using WebApi.Services;
using GYMDAL.DAO;
using GYMDAL.Data;
using GYMDAL.Identity;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ServiceLayer.Interfaces;
using ServiceLayer;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
			services.AddDbContext<GymContext>(options => {
				options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
				options.ConfigureWarnings(x => x.Ignore(RelationalEventId.AmbientTransactionWarning));
			});

			services.AddIdentity<GymUser, UserRole>().AddDefaultTokenProviders();
			services.AddTransient<IUserStore<GymUser>, UserStore>();
			services.AddTransient<IRoleStore<UserRole>, RoleStore>();

			// Add application services.
			services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
