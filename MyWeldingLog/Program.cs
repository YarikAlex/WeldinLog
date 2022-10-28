using Microsoft.EntityFrameworkCore;
using MyWeldingLog.DAL;
using MyWeldingLog.DAL.Interfaces.CatalogMaterials;
using MyWeldingLog.DAL.Interfaces.Hierarchy;
using MyWeldingLog.DAL.Interfaces.ProjectMaterials;
using MyWeldingLog.DAL.Repositories.CatalogMaterials;
using MyWeldingLog.DAL.Repositories.Hierarchy;
using MyWeldingLog.DAL.Repositories.ProjectMaterials;

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
            //Catalog
            builder.Services.AddScoped<IBranchRepository, BranchRepository>();
            builder.Services.AddScoped<IPipeRepository, PipeRepository>();

            //Project
            builder.Services.AddScoped<IProjectBranchMaterialRepository, ProjectBranchMaterialRepository>();
            builder.Services.AddScoped<IProjectPipeMaterialRepository, ProjectPipeMaterialRepository>();

            //Hierarchy
            builder.Services.AddScoped<IObjectRepository, ObjectRepository>();
            builder.Services.AddScoped<ISubObjectRepository, SubObjectRepository>();
            builder.Services.AddScoped<IProjectCodeRepository, ProjectCodeRepository>();

            var app = builder.Build();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}");
            app.Run();
        }
    }
}