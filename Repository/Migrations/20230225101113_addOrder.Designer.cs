﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

#nullable disable

namespace Repository.Migrations
{
    [DbContext(typeof(EStoreDBContext))]
    [Migration("20230225101113_addOrder")]
    partial class addOrder
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Repository.Entity.Order", b =>
                {
                    b.Property<Guid>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CustomerUsername")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderID");

                    b.HasIndex("CustomerUsername");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("Repository.Entity.OrderDetail", b =>
                {
                    b.Property<Guid>("OrderDetailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderDetailID");

                    b.HasIndex("OrderID");

                    b.HasIndex("ProductID")
                        .IsUnique();

                    b.ToTable("OrderDetail");
                });

            modelBuilder.Entity("Repository.Entity.Permission", b =>
                {
                    b.Property<Guid>("PermissionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PermissionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("PermissionID");

                    b.HasIndex("RoleName");

                    b.ToTable("permissions");

                    b.HasData(
                        new
                        {
                            PermissionID = new Guid("4d888760-d5fc-4e8e-be18-8427c3e21b58"),
                            PermissionName = "Edit",
                            RoleName = "Admin"
                        },
                        new
                        {
                            PermissionID = new Guid("07d63881-42cf-4fa4-8db9-3351c5e07f6e"),
                            PermissionName = "Update",
                            RoleName = "Admin"
                        },
                        new
                        {
                            PermissionID = new Guid("4d57ed17-b1a4-4fd4-ae99-097486fe34bb"),
                            PermissionName = "Delete",
                            RoleName = "Admin"
                        });
                });

            modelBuilder.Entity("Repository.Entity.Product", b =>
                {
                    b.Property<Guid>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductID");

                    b.ToTable("products");

                    b.HasData(
                        new
                        {
                            ProductID = new Guid("44a2834d-66e3-4b31-8aac-afe141b2cad1"),
                            Description = "Description",
                            Image = "Image",
                            Price = 50.049999999999997,
                            ProductName = "A Regular Table"
                        },
                        new
                        {
                            ProductID = new Guid("4f08b49b-ffc5-459b-bbc0-ef5fe25bb444"),
                            Description = "Description a little bit different from above",
                            Image = "Irregular Image",
                            Price = 1.0069999999999999,
                            ProductName = "A Irregular Table"
                        });
                });

            modelBuilder.Entity("Repository.Entity.Role", b =>
                {
                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RoleName");

                    b.ToTable("roles");

                    b.HasData(
                        new
                        {
                            RoleName = "Admin"
                        });
                });

            modelBuilder.Entity("Repository.Entity.User", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Username");

                    b.HasIndex("RoleName");

                    b.ToTable("users");

                    b.HasData(
                        new
                        {
                            Username = "Admin",
                            DateOfBirth = new DateTime(2002, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "ColorfulKhalid@gmail.com",
                            FullName = "Khalid Mai",
                            Gender = true,
                            Password = "HelloWorld",
                            RoleName = "Admin"
                        });
                });

            modelBuilder.Entity("Repository.Entity.Order", b =>
                {
                    b.HasOne("Repository.Entity.User", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerUsername")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Repository.Entity.OrderDetail", b =>
                {
                    b.HasOne("Repository.Entity.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Repository.Entity.Product", "Product")
                        .WithOne("OrderDetail")
                        .HasForeignKey("Repository.Entity.OrderDetail", "ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Repository.Entity.Permission", b =>
                {
                    b.HasOne("Repository.Entity.Role", "Role")
                        .WithMany("Pemissions")
                        .HasForeignKey("RoleName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Repository.Entity.User", b =>
                {
                    b.HasOne("Repository.Entity.Role", "UserRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("Repository.Entity.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("Repository.Entity.Product", b =>
                {
                    b.Navigation("OrderDetail")
                        .IsRequired();
                });

            modelBuilder.Entity("Repository.Entity.Role", b =>
                {
                    b.Navigation("Pemissions");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
