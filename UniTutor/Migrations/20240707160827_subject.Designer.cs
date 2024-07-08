﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UniTutor.DataBase;

#nullable disable

namespace UniTutor.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20240707160827_subject")]
    partial class subject
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("UniTutor.Model.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("UniTutor.Model.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("commentText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("stuId")
                        .HasColumnType("int");

                    b.Property<DateTime>("time")
                        .HasColumnType("datetime2");

                    b.Property<int?>("tutId")
                        .HasColumnType("int");

                    b.Property<string>("userType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("stuId");

                    b.HasIndex("tutId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("UniTutor.Model.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("availability")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("medium")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.Property<int>("studentId")
                        .HasColumnType("int");

                    b.Property<string>("subjectId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("tutorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("studentId");

                    b.HasIndex("tutorId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("UniTutor.Model.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("VerificationCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("district")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("grade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("numberofcomplain")
                        .HasColumnType("int");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("profileImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("schoolName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("UniTutor.Model.Subject", b =>
                {
                    b.Property<int>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("_id"));

                    b.Property<int?>("RequestId")
                        .HasColumnType("int");

                    b.Property<string>("availability")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("coverImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("medium")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("tutorId")
                        .HasColumnType("int");

                    b.HasKey("_id");

                    b.HasIndex("RequestId");

                    b.HasIndex("tutorId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("UniTutor.Model.Tutor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProfileUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VerificationCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("district")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("occupation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("qualifications")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("universityID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("universityMail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("verified")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Tutors");
                });

            modelBuilder.Entity("UniTutor.Model.Comment", b =>
                {
                    b.HasOne("UniTutor.Model.Student", "Student")
                        .WithMany("Comments")
                        .HasForeignKey("stuId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UniTutor.Model.Tutor", "Tutor")
                        .WithMany("Comments")
                        .HasForeignKey("tutId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Student");

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("UniTutor.Model.Request", b =>
                {
                    b.HasOne("UniTutor.Model.Student", "Student")
                        .WithMany()
                        .HasForeignKey("studentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniTutor.Model.Tutor", "Tutor")
                        .WithMany()
                        .HasForeignKey("tutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("UniTutor.Model.Subject", b =>
                {
                    b.HasOne("UniTutor.Model.Request", null)
                        .WithMany("Subjects")
                        .HasForeignKey("RequestId");

                    b.HasOne("UniTutor.Model.Tutor", "Tutor")
                        .WithMany("Subjects")
                        .HasForeignKey("tutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("UniTutor.Model.Request", b =>
                {
                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("UniTutor.Model.Student", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("UniTutor.Model.Tutor", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Subjects");
                });
#pragma warning restore 612, 618
        }
    }
}
