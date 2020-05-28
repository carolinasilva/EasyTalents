using EasyTalents.Infra.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using EasyTalents.Domain.Services;
using EasyTalents.Domain.Interfaces.Services;
using EasyTalents.Domain.Interfaces.Repositories;
using EasyTalents.Infra.Repositories;
using FluentValidation.AspNetCore;
using FluentValidation;
using EasyTalents.Domain.Entities;
using EasyTalents.Domain.Validators;
using AutoMapper;
using EasyTalents.Domain.Mapping;

namespace EasyTalents.API
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

            services.AddDbContext<EasyTalentsContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc().AddFluentValidation();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DomainMappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            // Services Injection
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddScoped<ICandidateService, CandidateService>();
            services.AddScoped<ICandidateBestTimeService, CandidateBestTimeService>();
            services.AddScoped<ICandidateKnowledgeService, CandidateKnowledgeService>();
            services.AddScoped<ICandidateWorkingTimeService, CandidateWorkingTimeService>();
            // End Services Injection

            // Repositories Injection
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<DbContext, EasyTalentsContext>();
            // Repositories Injection

            // Validators
            services.AddTransient<IValidator<Candidate>, CandidateValidator>();
            // End Validators 

            //CORS
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
