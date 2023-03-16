using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MyWeldingLog.DAL;
using MyWeldingLog.DAL.Interfaces.Hierarchy;
using MyWeldingLog.DAL.Interfaces.ProjectMaterials;
using MyWeldingLog.DAL.Repositories.Hierarchy;
using MyWeldingLog.DAL.Repositories.ProjectMaterials;
using MyWeldingLog.Service.Implementations.Hierarchy;
using MyWeldingLog.Service.Interfaces.Hierarchy;
using FluentValidation.AspNetCore;
using MyWeldingLog.Models.Requests.Objects;
using MyWeldingLog.Service.Exceptions.BaseException;
using MyWeldingLog.Service.Exceptions.ExceptionHandler;
using MyWeldingLog.Validators.Objects;

namespace MyWeldingLog
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ApplicationDbContext>(o =>
                o.UseNpgsql(builder.Configuration.GetConnectionString("WeldingLog")));
            builder.Services.AddSingleton<ExceptionFilter>();
            builder.Services.AddControllers(x => x.Filters.Add<ExceptionFilter>())
                .AddFluentValidation(
                    x =>
                    {
                        x.ImplicitlyValidateChildProperties = true;
                        x.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
                    });

            //Project Materials
            builder.Services.AddScoped<IProjectMaterialRepository, ProjectMaterialRepository>();

            //Hierarchy
            builder.Services.AddScoped<IObjectRepository, ObjectRepository>();
            builder.Services.AddScoped<ISubObjectRepository, SubObjectRepository>();
            builder.Services.AddScoped<IProjectCodeRepository, ProjectCodeRepository>();
            builder.Services.AddScoped<IHierarchyRepository, HierarchyRepository>();
            builder.Services.AddScoped<IClusterRepository, ClusterRepository>();
            builder.Services.AddScoped<IJobRepository, JobRepository>();
            builder.Services.AddScoped<IJobTypeRepository, JobTypeRepository>();
            
            builder.Services.AddScoped<IObjectService, ObjectService>();
            builder.Services.AddScoped<ISubObjectService, SubObjectService>();
            builder.Services.AddScoped<IHierarchyService, HierarchyService>();
            builder.Services.AddScoped<IProjectCodeService, ProjectCodeService>();

            var app = builder.Build();
            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    options.RoutePrefix = string.Empty;
                });
            app.UseHttpsRedirection();
            app.MapControllers();

            app.Run();
        }
    }
}