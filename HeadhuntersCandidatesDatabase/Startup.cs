using HeadhuntersCandidatesDatabase.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeadhuntersCandidatesDatabase.Core.Interfaces;
using HeadhuntersCandidatesDatabase.Core.Models;
using HeadhuntersCandidatesDatabase.Data;
using HeadhuntersCandidatesDatabase.Services.Services;

namespace HeadhuntersCandidatesDatabase
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HeadhuntersCandidatesDatabase", Version = "v1" });
            });
            services.AddDbContext<HeadhuntersCandidatesDatabaseDbContext>
         (o => o.UseSqlServer(Configuration.GetConnectionString("HeadhuntersCandidatesDatabase2")));
            
            services.AddScoped<ICandidatesDataAccess, CandidatesDataAccess>();
            services.AddScoped<ICompaniesDataAccess, CompaniesDataAccess>();
            services.AddScoped<IHeadhuntersCandidatesDatabaseDbContext, HeadhuntersCandidatesDatabaseDbContext>();
            services.AddScoped<IEntityService<Candidate>, EntityService<Candidate>>();
            services.AddScoped<IEntityService<Company>, EntityService<Company>>();
            services.AddScoped<IDbService, DbService>();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200").AllowAnyHeader()
                            .AllowCredentials()
                            .AllowAnyMethod();
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HeadhuntersCandidatesDatabase v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(builder =>
            {
                builder.WithOrigins("http://localhost:4200").AllowAnyHeader()
                    .AllowCredentials()
                    .AllowAnyMethod();
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
