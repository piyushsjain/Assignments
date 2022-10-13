using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ReimbursementPortal.BusinessLayer.Services;
using ReimbursementPortal.DataAccessLayer.Data;
using ReimbursementPortal.DataAccessLayer.IRepository;
using ReimbursementPortal.DataAccessLayer.Repository;
using ReimbursementPortal.PresentationLayer.Converters;
using ReimbursementPortal.SharedLayer.DataTransferObjects;
using ReimbursementPortal.SharedLayer.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReimbursementPortal.PresentationLayer
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
            services.AddDbContext<ReimbursementContext>(options => options.UseSqlServer("Server=IN-PG02P7FG;Database=ReimbursementPortal;Integrated Security=true;"));
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ReimbursementContext>();

            /*services.Configure<IdentityOptions>(Options =>
            {
                Options.Password.RequiredLength = 8;
                Options.Password.RequireNonAlphanumeric = true;
                Options.Password.RequireDigit = true;
                Options.Password.RequireLowercase = false;
                Options.Password.RequireUppercase = false;

            });*/

            services.AddControllers().AddJsonOptions(options => 
            {
                options.JsonSerializerOptions.Converters.Add(new DateConverter());
            
            }) ;
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ReimbursementPortal.PresentationLayer", Version = "v1" });
            });

            //Context
            services.AddScoped<ReimbursementContext, ReimbursementContext>();

            //Services
            services.AddScoped<IAccountServices, AccountServices>();
            services.AddScoped<IReimbursementServices, ReimbursementServices>();
            services.AddScoped<IAdminServices, AdminServices>();

            //Repository
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IReimbursementRepository, ReimbursementRepository>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IUserService, UserService>();
           

          

            services.AddCors();

           

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options =>  
            options.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader()
            );
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ReimbursementPortal.PresentationLayer v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
