using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SistemaBancarioAPI.Repositories;
using System;
using System.IO;

namespace SistemaBancarioAPI.Context
{
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();

            var path = Directory.GetCurrentDirectory();

            var configuration = new ConfigurationBuilder()
               .SetBasePath(path)              
               .AddJsonFile($"appsettings.Development.json", optional: false, reloadOnChange: true)
               .AddEnvironmentVariables()
               .Build();           

            var defaultConnection = configuration.GetConnectionString("DefaultConnection");
            Console.WriteLine($"defaultConnection:{defaultConnection}");

            optionsBuilder.UseNpgsql(defaultConnection);
            return new DatabaseContext(optionsBuilder.Options);
        }
    }
}