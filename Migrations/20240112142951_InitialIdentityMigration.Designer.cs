﻿// <auto-generated />
using System;
using CarService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarService.Migrations
{
    [DbContext(typeof(CarServiceContext))]
    [Migration("20240112142951_InitialIdentityMigration")]
    partial class InitialIdentityMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CarService.Models.Appointment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("ClientID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ServiceID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.ToTable("Appointment");
                });

            modelBuilder.Entity("CarService.Models.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("CarService.Models.Group", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("CarService.Models.Room", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("RoomName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("CarService.Models.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceId"), 1L, 1);

                    b.Property<int?>("AppointmentID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6,2)");

                    b.Property<int?>("RoomID")
                        .HasColumnType("int");

                    b.HasKey("ServiceId");

                    b.HasIndex("AppointmentID")
                        .IsUnique()
                        .HasFilter("[AppointmentID] IS NOT NULL");

                    b.HasIndex("RoomID");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("CarService.Models.ServiceGroup", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("GroupID")
                        .HasColumnType("int");

                    b.Property<int>("ServiceID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("GroupID");

                    b.HasIndex("ServiceID");

                    b.ToTable("ServiceGroup");
                });

            modelBuilder.Entity("CarService.Models.Appointment", b =>
                {
                    b.HasOne("CarService.Models.Client", "Client")
                        .WithMany("Appointments")
                        .HasForeignKey("ClientID");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("CarService.Models.Service", b =>
                {
                    b.HasOne("CarService.Models.Appointment", "Appointment")
                        .WithOne("Service")
                        .HasForeignKey("CarService.Models.Service", "AppointmentID");

                    b.HasOne("CarService.Models.Room", "Room")
                        .WithMany("Services")
                        .HasForeignKey("RoomID");

                    b.Navigation("Appointment");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("CarService.Models.ServiceGroup", b =>
                {
                    b.HasOne("CarService.Models.Group", "Group")
                        .WithMany("ServiceGroups")
                        .HasForeignKey("GroupID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarService.Models.Service", "Service")
                        .WithMany("ServiceGroups")
                        .HasForeignKey("ServiceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("CarService.Models.Appointment", b =>
                {
                    b.Navigation("Service");
                });

            modelBuilder.Entity("CarService.Models.Client", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("CarService.Models.Group", b =>
                {
                    b.Navigation("ServiceGroups");
                });

            modelBuilder.Entity("CarService.Models.Room", b =>
                {
                    b.Navigation("Services");
                });

            modelBuilder.Entity("CarService.Models.Service", b =>
                {
                    b.Navigation("ServiceGroups");
                });
#pragma warning restore 612, 618
        }
    }
}
