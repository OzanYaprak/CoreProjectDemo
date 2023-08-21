using CoreProjectDemo.Models;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CoreProjectDemo
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
            //******IDENTITY KÜTÜP. ÝLE BÝRLÝKTE YAZILDI
            services.AddDbContext<SQLContext>();
            services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<SQLContext>().AddErrorDescriber<CustomIdentityValidator>();
            //******


            services.AddControllersWithViews();

            //AUTHENTICATION ISLEMLERI ICIN YAZILDI (SETTINGS/LOGIN/LOGOUT)
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            services.ConfigureApplicationCookie(options => 
            {
                options.LoginPath = "/Login/Index";
                options.LogoutPath = "/Login/Logout";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            //AUTHENTICATION ISLEMLERI ICIN YAZILDI (SETTINGS/LOGIN/LOGOUT)
            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
