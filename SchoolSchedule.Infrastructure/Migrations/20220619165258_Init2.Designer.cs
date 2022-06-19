﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolSchedule.Infrastructure.Data;

#nullable disable

namespace SchoolSchedule.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220619165258_Init2")]
    partial class Init2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SchoolSchedule.Domain.EducationalClassAggregate.EducationalClass", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.ToTable("EducationalClasses", (string)null);
                });

            modelBuilder.Entity("SchoolSchedule.Domain.EducationalClassAggregate.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthYear")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EducationalClassId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("EducationalClassId");

                    b.ToTable("Students", (string)null);
                });

            modelBuilder.Entity("SchoolSchedule.Domain.EducationalClassAggregate.Student", b =>
                {
                    b.HasOne("SchoolSchedule.Domain.EducationalClassAggregate.EducationalClass", "EducationalClass")
                        .WithMany("Students")
                        .HasForeignKey("EducationalClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EducationalClass");
                });

            modelBuilder.Entity("SchoolSchedule.Domain.EducationalClassAggregate.EducationalClass", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
