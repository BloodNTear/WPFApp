using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DBContextFactory : IDesignTimeDbContextFactory<EStoreDBContext>
    {
        public EStoreDBContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            var builder = new DbContextOptionsBuilder<EStoreDBContext>();
            var connectionString = configuration.GetConnectionString("defaultConnection");
            builder.UseSqlServer(connectionString);

            return new EStoreDBContext(builder.Options);
        }
    }
}
