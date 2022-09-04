using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PSW.Model.MyDbContext;
using PSW.Repository.IRepo;
using PSW.Repository.Repo;
using PSW.Service.AppointmentHistoryService;
using PSW.Service.AppointmentService;
using PSW.Service.ReferralService.cs;
using PSW.Service.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSW
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

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
                    });

            services.AddAuthorization();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PSW", Version = "v1" });
            });

            services.AddDbContext<MyDbContext>(options =>
            options.UseMySql(Configuration.GetConnectionString("MyDbContextConnectionString"), new MySqlServerVersion(new Version())).UseLazyLoadingProxies());

            services.AddScoped<IPatientRepository, PatientRepoBase>();
            services.AddScoped<IDoctorRepository, DoctorRepoBase>();
            services.AddScoped<IAppointmentRepository, AppointmentRepoBase>();
            services.AddScoped<IReferralRepository, ReferralRepoBase>();
            services.AddScoped<IAppointmentHistoryRepository, AppointmentHistoryRepoBase>();


            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IReferralService, ReferralService>();
            services.AddScoped<IAppointmentHistoryService, AppointmentHistoryService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            services.AddCors();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options =>
           options.WithOrigins("http://localhost:3000")
           .AllowAnyHeader()
           .AllowAnyMethod());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PSW v1"));
            }

            //app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
