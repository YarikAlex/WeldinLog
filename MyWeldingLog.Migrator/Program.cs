using System;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using MyWeldingLog.Migrator.Migrations;

namespace MyWeldingLog.Migrator
{
    static class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = CreateServices();
            using var scope = serviceProvider.CreateScope();
            UpdateDatabase(scope.ServiceProvider);
        }

        private static IServiceProvider CreateServices()
        {
            return new ServiceCollection().AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddPostgres()
                    .WithGlobalConnectionString(@"
                                        Server=localhost;Port=22051;
                                        User Id=postgres;
                                        Password=mysecretpassword;
                                        Database=weldingLog;")
                    .ScanIn(typeof(Init).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }
    }
}