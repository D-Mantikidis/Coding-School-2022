﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Petshop.EF;

#nullable disable

namespace Petshop.EF.Migrations
{
    [DbContext(typeof(PetShopContext))]
    [Migration("20220323142703_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Customer", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36)
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ObjectStatus")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Tin")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("ID");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("Employee", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36)
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("EmpType")
                        .HasMaxLength(20)
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int>("ObjectStatus")
                        .HasColumnType("int");

                    b.Property<decimal>("Salary")
                        .HasMaxLength(20)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("ID");

                    b.ToTable("Employee", (string)null);
                });

            modelBuilder.Entity("Pet", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36)
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AnimalType")
                        .HasMaxLength(60)
                        .HasColumnType("int");

                    b.Property<string>("Breed")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<decimal>("Cost")
                        .HasMaxLength(20)
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("FoodTypeID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("HealthStatus")
                        .HasMaxLength(60)
                        .HasColumnType("int");

                    b.Property<int>("ObjectStatus")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasMaxLength(20)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("FoodTypeID");

                    b.ToTable("Pet", (string)null);
                });

            modelBuilder.Entity("PetFood", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36)
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<decimal>("Cost")
                        .HasMaxLength(20)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ObjectStatus")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasMaxLength(20)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Type")
                        .HasMaxLength(60)
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("PetFood", (string)null);
                });

            modelBuilder.Entity("PetShopLibrary.Transaction", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36)
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerID")
                        .HasMaxLength(36)
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasMaxLength(60)
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EmployeeID")
                        .HasMaxLength(36)
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PetFoodID")
                        .HasMaxLength(36)
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("PetFoodPrice")
                        .HasMaxLength(100)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PetFoodQty")
                        .HasMaxLength(20)
                        .HasColumnType("int");

                    b.Property<Guid>("PetID")
                        .HasMaxLength(36)
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("PetPrice")
                        .HasMaxLength(100)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalPrice")
                        .HasMaxLength(100)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.ToTable("Transaction", (string)null);
                });

            modelBuilder.Entity("Pet", b =>
                {
                    b.HasOne("PetFood", "FoodType")
                        .WithMany()
                        .HasForeignKey("FoodTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FoodType");
                });
#pragma warning restore 612, 618
        }
    }
}
