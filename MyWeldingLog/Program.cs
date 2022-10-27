using Microsoft.EntityFrameworkCore;
using MyWeldingLog.DAL;
using MyWeldingLog.DAL.Interfaces;
using MyWeldingLog.DAL.Repositories;

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
            builder.Services.AddScoped<IBranchRepository, BranchRepository>();

            var app = builder.Build();
            app.Run();
        }
    }
}