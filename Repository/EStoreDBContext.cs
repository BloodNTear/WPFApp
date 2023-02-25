using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository.Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class EStoreDBContext : DbContext
    {
        public EStoreDBContext(DbContextOptions<EStoreDBContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            var builder = new DbContextOptionsBuilder<EStoreDBContext>();
            var connectionString = configuration.GetConnectionString("defaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }

        #region DBSet
        public DbSet<User> users { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<Permission> permissions { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Order> orders { get; set; }
        #endregion

        #region Data Seed
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Relationships
            modelBuilder.Entity<User>()
            .HasOne(u => u.UserRole)
            .WithMany(r => r.Users)
            .HasForeignKey(u => u.RoleName);

            modelBuilder.Entity<Role>()
                .HasMany(r => r.Pemissions)
                .WithOne(p => p.Role)
                .HasForeignKey(p => p.RoleName);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderDetails)
                .WithOne(od => od.Order)
                .HasForeignKey(od => od.OrderID);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Product)
                .WithOne(p => p.OrderDetail)
                .HasForeignKey<OrderDetail>(od => od.ProductID);
            #endregion

            #region Default Role And Permission
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    RoleName = "Admin",
                }
            );

            modelBuilder.Entity<Permission>().HasData(
                new Permission { PermissionID = Guid.NewGuid(), PermissionName = "Edit", RoleName = "Admin" },
                new Permission { PermissionID = Guid.NewGuid(), PermissionName = "Update", RoleName = "Admin" },
                new Permission { PermissionID = Guid.NewGuid(), PermissionName = "Delete", RoleName = "Admin" }
            );
            #endregion

            #region Default Admin
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Username = "Admin",
                    Password = "HelloWorld",
                    DateOfBirth = DateTime.ParseExact("16/01/2002", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Email = "ColorfulKhalid@gmail.com",
                    FullName = "Khalid Mai",
                    Gender = true,
                    RoleName = "Admin"
                }
            );
            #endregion

            #region Default Product
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductID = Guid.NewGuid(),
                    ProductName = "A Regular Table",
                    Description = "Description",
                    Image = "Image",
                    Price = 50.05

                },
                new Product
                {
                    ProductID = Guid.NewGuid(),
                    ProductName = "A Irregular Table",
                    Description = "Description a little bit different from above",
                    Image = "Irregular Image",
                    Price = 1.007
                }
                );
            #endregion
        }
        #endregion
    }
}
