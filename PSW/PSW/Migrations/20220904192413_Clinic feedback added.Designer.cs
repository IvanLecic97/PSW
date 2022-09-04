﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PSW.Model.MyDbContext;

namespace PSW.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20220904192413_Clinic feedback added")]
    partial class Clinicfeedbackadded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("PSW.Model.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<string>("DoctorType")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsOver")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsRewieved")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsTaken")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Appointment");
                });

            modelBuilder.Entity("PSW.Model.AppointmentHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AppointmentComment")
                        .HasColumnType("longtext");

                    b.Property<int>("AppointmentId")
                        .HasColumnType("int");

                    b.Property<double>("DoctorRating")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("AppointmentHistory");
                });

            modelBuilder.Entity("PSW.Model.ClinicFeedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Anonymous")
                        .HasColumnType("tinyint(1)");

                    b.Property<double>("Rating")
                        .HasColumnType("double");

                    b.Property<string>("Text")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("ClinicFeedback");
                });

            modelBuilder.Entity("PSW.Model.Referral", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AppointmentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("AppointmentTime")
                        .HasColumnType("datetime");

                    b.Property<int>("FamilyDoctorId")
                        .HasColumnType("int");

                    b.Property<string>("FileName")
                        .HasColumnType("longtext");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<int>("SpecialistId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Referrals");
                });

            modelBuilder.Entity("PSW.Model.Users.RegUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime");

                    b.Property<string>("City")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext");

                    b.Property<string>("Surname")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("RegUser");
                });

            modelBuilder.Entity("PSW.Model.Users.Admin", b =>
                {
                    b.HasBaseType("PSW.Model.Users.RegUser");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("PSW.Model.Users.Doctor", b =>
                {
                    b.HasBaseType("PSW.Model.Users.RegUser");

                    b.Property<string>("DoctorType")
                        .HasColumnType("longtext");

                    b.ToTable("Doctor");
                });

            modelBuilder.Entity("PSW.Model.Users.Patient", b =>
                {
                    b.HasBaseType("PSW.Model.Users.RegUser");

                    b.Property<string>("BloodType")
                        .HasColumnType("longtext");

                    b.Property<string>("HealthCard")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsBlockable")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("MedicalRecordId")
                        .HasColumnType("int");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("PSW.Model.Users.Admin", b =>
                {
                    b.HasOne("PSW.Model.Users.RegUser", null)
                        .WithOne()
                        .HasForeignKey("PSW.Model.Users.Admin", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PSW.Model.Users.Doctor", b =>
                {
                    b.HasOne("PSW.Model.Users.RegUser", null)
                        .WithOne()
                        .HasForeignKey("PSW.Model.Users.Doctor", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PSW.Model.Users.Patient", b =>
                {
                    b.HasOne("PSW.Model.Users.RegUser", null)
                        .WithOne()
                        .HasForeignKey("PSW.Model.Users.Patient", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
