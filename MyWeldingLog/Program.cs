using Microsoft.EntityFrameworkCore;
using MyWeldingLog.DAL;
using MyWeldingLog.DAL.Interfaces.Hierarchy;
using MyWeldingLog.DAL.Interfaces.InboundMaterials;
using MyWeldingLog.DAL.Interfaces.ProjectMaterials;
using MyWeldingLog.DAL.Repositories.Hierarchy;
using MyWeldingLog.DAL.Repositories.InboundMaterials;
using MyWeldingLog.DAL.Repositories.ProjectMaterials;
using MyWeldingLog.Service.Implementations.Hierarchy;
using MyWeldingLog.Service.Implementations.ProjectMaterials;
using MyWeldingLog.Service.Interfaces.Hierarchy;
using MyWeldingLog.Service.Interfaces.ProjectMaterials;

namespace MyWeldingLog
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ApplicationDbContext>(o =>
                o.UseNpgsql(builder.Configuration.GetConnectionString("WeldingLog")));
            builder.Services.AddControllers();

            //Project Materials
            builder.Services.AddScoped<IProjectBranchMaterialRepository, ProjectBranchMaterialRepository>();
            builder.Services.AddScoped<IProjectPipeMaterialRepository, ProjectPipeMaterialRepository>();
            builder.Services.AddScoped<IProjectPipeMaterialService, ProjectPipeMaterialService>();
            builder.Services.AddScoped<IProjectBranchMaterialService, ProjectBranchMaterialService>();

            //Hierarchy
            builder.Services.AddScoped<IObjectRepository, ObjectRepository>();
            builder.Services.AddScoped<ISubObjectRepository, SubObjectRepository>();
            builder.Services.AddScoped<IProjectCodeRepository, ProjectCodeRepository>();
            builder.Services.AddScoped<IHierarchyRepository, HierarchyRepository>();
            builder.Services.AddScoped<IObjectService, ObjectService>();
            builder.Services.AddScoped<ISubObjectService, SubObjectService>();
            builder.Services.AddScoped<IHierarchyService, HierarchyService>();

            //Actual Materials
            builder.Services.AddScoped<IInboundPipeMaterialRepository, InboundPipeMaterialRepository>();
            builder.Services.AddScoped<IInboundBranchMaterialRepository, InboundBranchMaterialRepository>();

            var app = builder.Build();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}");

            app.Run();
        }
    }
}