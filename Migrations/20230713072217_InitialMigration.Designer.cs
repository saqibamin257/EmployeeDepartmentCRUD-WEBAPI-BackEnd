﻿// <auto-generated />
using System;
using EmployeeDepartment_CRUD_WEBAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeeDepartment_CRUD_WEBAPI.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20230713072217_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EmployeeDepartment_CRUD_Model.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DepartmentName = "Sales"
                        },
                        new
                        {
                            Id = 2,
                            DepartmentName = "Production"
                        },
                        new
                        {
                            Id = 3,
                            DepartmentName = "IT"
                        },
                        new
                        {
                            Id = 4,
                            DepartmentName = "Accounts"
                        });
                });

            modelBuilder.Entity("EmployeeDepartment_CRUD_Model.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateOfJoining")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PhotoFileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfJoining = new DateTime(2023, 7, 13, 12, 22, 17, 17, DateTimeKind.Local).AddTicks(5890),
                            DepartmentId = 1,
                            EmployeeName = "Saqib",
                            PhotoFileName = "anonymous.png"
                        },
                        new
                        {
                            Id = 2,
                            DateOfJoining = new DateTime(2023, 7, 13, 12, 22, 17, 17, DateTimeKind.Local).AddTicks(5940),
                            DepartmentId = 2,
                            EmployeeName = "Malik",
                            PhotoFileName = "anonymous.png"
                        },
                        new
                        {
                            Id = 3,
                            DateOfJoining = new DateTime(2023, 7, 13, 12, 22, 17, 17, DateTimeKind.Local).AddTicks(5957),
                            DepartmentId = 3,
                            EmployeeName = "Imran",
                            PhotoFileName = "anonymous.png"
                        },
                        new
                        {
                            Id = 4,
                            DateOfJoining = new DateTime(2023, 7, 13, 12, 22, 17, 17, DateTimeKind.Local).AddTicks(5970),
                            DepartmentId = 4,
                            EmployeeName = "Farhan",
                            PhotoFileName = "anonymous.png"
                        });
                });

            modelBuilder.Entity("EmployeeDepartment_CRUD_Model.Employee", b =>
                {
                    b.HasOne("EmployeeDepartment_CRUD_Model.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });
#pragma warning restore 612, 618
        }
    }
}
