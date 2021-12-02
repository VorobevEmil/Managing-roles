using Managing_roles.Data;
using Managing_roles.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Managing_roles
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("SqlLiteConnection")));

            services.AddAuthentication(IISDefaults.AuthenticationScheme);

            services.AddMvc();

            services.AddScoped<RoleService>();
            services.AddScoped<UserService>();
            services.AddScoped<RoleUserService>();
            services.AddScoped<DataManager>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStatusCodePagesWithRedirects("/Errors/{0}");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Errors/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthorization();

            app.UseMiddleware<UserRolesMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
