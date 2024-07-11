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
    [Migration("20240711045450_varsha5")]
    partial class varsha5
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
                    b.Property<int>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("_id"));

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

                    b.HasKey("_id");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("UniTutor.Model.Comment", b =>
                {
                    b.Property<int>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("_id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("commentText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("stuId")
                        .HasColumnType("int");

                    b.Property<int?>("tutId")
                        .HasColumnType("int");

                    b.Property<string>("userType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("_id");

                    b.HasIndex("stuId");

                    b.HasIndex("tutId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("UniTutor.Model.Report", b =>
                {
                    b.Property<int>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("_id"));

                    b.Property<int?>("Student_id")
                        .HasColumnType("int");

                    b.Property<int?>("Tutor_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("receiverMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("senderMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("studentId")
                        .HasColumnType("int");

                    b.Property<int?>("tutorId")
                        .HasColumnType("int");

                    b.HasKey("_id");

                    b.HasIndex("Student_id");

                    b.HasIndex("Tutor_id");

                    b.HasIndex("studentId");

                    b.HasIndex("tutorId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("UniTutor.Model.Request", b =>
                {
                    b.Property<int>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("_id"));

                    b.Property<bool>("IsAccepted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRejected")
                        .HasColumnType("bit");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("studentEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("studentId")
                        .HasColumnType("int");

                    b.Property<int>("subjectId")
                        .HasColumnType("int");

                    b.Property<DateTime>("timestamp")
                        .HasColumnType("datetime2");

                    b.Property<int>("tutorId")
                        .HasColumnType("int");

                    b.HasKey("_id");

                    b.HasIndex("studentId");

                    b.HasIndex("subjectId");

                    b.HasIndex("tutorId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("UniTutor.Model.Student", b =>
                {
                    b.Property<int>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("_id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProfileUrl")
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("schoolName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("_id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("UniTutor.Model.Subject", b =>
                {
                    b.Property<int>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("_id"));

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

                    b.HasIndex("tutorId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("UniTutor.Model.TodoItem", b =>
                {
                    b.Property<int>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("_id"));

                    b.Property<bool>("isCompleted")
                        .HasColumnType("bit");

                    b.Property<int?>("studentId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("tutorId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("_id");

                    b.HasIndex("studentId");

                    b.HasIndex("tutorId");

                    b.ToTable("TodoItems");
                });

            modelBuilder.Entity("UniTutor.Model.Tutor", b =>
                {
                    b.Property<int>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("_id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProfileUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VerificationCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Verified")
                        .HasColumnType("bit");

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

                    b.HasKey("_id");

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

            modelBuilder.Entity("UniTutor.Model.Report", b =>
                {
                    b.HasOne("UniTutor.Model.Student", null)
                        .WithMany("Reports")
                        .HasForeignKey("Student_id");

                    b.HasOne("UniTutor.Model.Tutor", null)
                        .WithMany("Reports")
                        .HasForeignKey("Tutor_id");

                    b.HasOne("UniTutor.Model.Student", "Student")
                        .WithMany()
                        .HasForeignKey("studentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("UniTutor.Model.Tutor", "Tutor")
                        .WithMany()
                        .HasForeignKey("tutorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Student");

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("UniTutor.Model.Request", b =>
                {
                    b.HasOne("UniTutor.Model.Student", "Student")
                        .WithMany("Requests")
                        .HasForeignKey("studentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("UniTutor.Model.Subject", "Subject")
                        .WithMany("Requests")
                        .HasForeignKey("subjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("UniTutor.Model.Tutor", "Tutor")
                        .WithMany("Requests")
                        .HasForeignKey("tutorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("UniTutor.Model.Subject", b =>
                {
                    b.HasOne("UniTutor.Model.Tutor", "Tutor")
                        .WithMany("Subjects")
                        .HasForeignKey("tutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("UniTutor.Model.TodoItem", b =>
                {
                    b.HasOne("UniTutor.Model.Student", "Student")
                        .WithMany("TodoLists")
                        .HasForeignKey("studentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniTutor.Model.Tutor", "Tutor")
                        .WithMany("TodoLists")
                        .HasForeignKey("tutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("UniTutor.Model.Student", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Reports");

                    b.Navigation("Requests");

                    b.Navigation("TodoLists");
                });

            modelBuilder.Entity("UniTutor.Model.Subject", b =>
                {
                    b.Navigation("Requests");
                });

            modelBuilder.Entity("UniTutor.Model.Tutor", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Reports");

                    b.Navigation("Requests");

                    b.Navigation("Subjects");

                    b.Navigation("TodoLists");
                });
#pragma warning restore 612, 618
        }
    }
}
