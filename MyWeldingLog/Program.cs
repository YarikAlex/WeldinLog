using Microsoft.EntityFrameworkCore;
using MyWeldingLog.DAL;
using MyWeldingLog.DAL.Interfaces.Hierarchy;
using MyWeldingLog.DAL.Interfaces.ProjectMaterials;
using MyWeldingLog.DAL.Repositories.Hierarchy;
using MyWeldingLog.DAL.Repositories.ProjectMaterials;
using MyWeldingLog.Service.Implementations.Hierarchy;
using MyWeldingLog.Service.Interfaces.Hierarchy;

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
            builder.Services.AddControllers();

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

            var app = builder.Build();
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.MapControllers();

            app.Run();
        }
    }
}