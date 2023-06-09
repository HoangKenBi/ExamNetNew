﻿// <auto-generated />
using System;
using ExamNet.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExamNet.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ExamNet.entities.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("classes");
                });

            modelBuilder.Entity("ExamNet.entities.Exam", b =>
                {
                    b.Property<int>("ExamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExamId"));

                    b.Property<DateTime>("ExamDate")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("ExamDuration")
                        .HasColumnType("time");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("classesId")
                        .HasColumnType("int");

                    b.Property<int?>("facultysId")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("subjectsId")
                        .HasColumnType("int");

                    b.HasKey("ExamId");

                    b.HasIndex("classesId");

                    b.HasIndex("facultysId");

                    b.HasIndex("subjectsId");

                    b.ToTable("exams");
                });

            modelBuilder.Entity("ExamNet.entities.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("faculty");
                });

            modelBuilder.Entity("ExamNet.entities.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("subject");
                });

            modelBuilder.Entity("ExamNet.entities.Exam", b =>
                {
                    b.HasOne("ExamNet.entities.Class", "classes")
                        .WithMany("Exams")
                        .HasForeignKey("classesId");

                    b.HasOne("ExamNet.entities.Faculty", "facultys")
                        .WithMany("exams")
                        .HasForeignKey("facultysId");

                    b.HasOne("ExamNet.entities.Subject", "subjects")
                        .WithMany("exams")
                        .HasForeignKey("subjectsId");

                    b.Navigation("classes");

                    b.Navigation("facultys");

                    b.Navigation("subjects");
                });

            modelBuilder.Entity("ExamNet.entities.Class", b =>
                {
                    b.Navigation("Exams");
                });

            modelBuilder.Entity("ExamNet.entities.Faculty", b =>
                {
                    b.Navigation("exams");
                });

            modelBuilder.Entity("ExamNet.entities.Subject", b =>
                {
                    b.Navigation("exams");
                });
#pragma warning restore 612, 618
        }
    }
}
