﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SMT_ITIWithDb.Models;

#nullable disable

namespace SMT_ITIWithDb.Migrations
{
    [DbContext(typeof(EmployeeContext))]
    partial class EmployeeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SMT_ITIWithDb.Models.Emp_Pro", b =>
                {
                    b.Property<int>("emp_id")
                        .HasColumnType("int");

                    b.Property<int>("pro_id")
                        .HasColumnType("int");

                    b.Property<int>("working_hours")
                        .HasColumnType("int");

                    b.HasKey("emp_id", "pro_id");

                    b.HasIndex("pro_id");

                    b.ToTable("Emp_Pros");
                });

            modelBuilder.Entity("SMT_ITIWithDb.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Office_Id")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salary")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Office_Id");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("SMT_ITIWithDb.Models.Office", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Offices");
                });

            modelBuilder.Entity("SMT_ITIWithDb.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("SMT_ITIWithDb.Models.Emp_Pro", b =>
                {
                    b.HasOne("SMT_ITIWithDb.Models.Employee", "Employee")
                        .WithMany("emp_Pros")
                        .HasForeignKey("emp_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SMT_ITIWithDb.Models.Project", "Project")
                        .WithMany("emp_Pros")
                        .HasForeignKey("pro_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("SMT_ITIWithDb.Models.Employee", b =>
                {
                    b.HasOne("SMT_ITIWithDb.Models.Office", "Office")
                        .WithMany("Employees")
                        .HasForeignKey("Office_Id");

                    b.Navigation("Office");
                });

            modelBuilder.Entity("SMT_ITIWithDb.Models.Employee", b =>
                {
                    b.Navigation("emp_Pros");
                });

            modelBuilder.Entity("SMT_ITIWithDb.Models.Office", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("SMT_ITIWithDb.Models.Project", b =>
                {
                    b.Navigation("emp_Pros");
                });
#pragma warning restore 612, 618
        }
    }
}