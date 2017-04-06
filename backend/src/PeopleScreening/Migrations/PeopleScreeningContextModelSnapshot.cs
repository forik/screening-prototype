﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PeopleScreening.Data;

namespace PeopleScreening.Migrations
{
    [DbContext(typeof(PeopleScreeningContext))]
    partial class PeopleScreeningContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:Sequence:.EntityFrameworkCoreSequence", "'EntityFrameworkCoreSequence', '', '1', '100', '', '', 'Int64', 'False'")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PeopleScreening.Model.Employee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "EntityFrameworkCoreSequence")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Alias");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<long?>("ManagerId");

                    b.Property<long?>("SkipManagerId");

                    b.Property<string>("TeamName");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.HasIndex("SkipManagerId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("PeopleScreening.Model.EmployeeScreening", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "EntityFrameworkCoreSequence")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<long?>("EmployeeId");

                    b.Property<DateTime?>("EndDate");

                    b.Property<DateTime>("ExpirationDate");

                    b.Property<bool>("NotificationIsInProgress");

                    b.Property<DateTime?>("NotificationSentDate");

                    b.Property<long?>("ScreeningId");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ScreeningId");

                    b.ToTable("EmployeeScreening");
                });

            modelBuilder.Entity("PeopleScreening.Model.ScreeningProcess", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "EntityFrameworkCoreSequence")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Description");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("ScreeningProcess");
                });

            modelBuilder.Entity("PeopleScreening.Model.Employee", b =>
                {
                    b.HasOne("PeopleScreening.Model.Employee", "Manager")
                        .WithMany("Employees")
                        .HasForeignKey("ManagerId");

                    b.HasOne("PeopleScreening.Model.Employee", "SkipManager")
                        .WithMany()
                        .HasForeignKey("SkipManagerId");
                });

            modelBuilder.Entity("PeopleScreening.Model.EmployeeScreening", b =>
                {
                    b.HasOne("PeopleScreening.Model.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("PeopleScreening.Model.ScreeningProcess", "Screening")
                        .WithMany()
                        .HasForeignKey("ScreeningId");
                });
        }
    }
}
