﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SVP.API.Data;

#nullable disable

namespace SVP.API.Migrations
{
    [DbContext(typeof(SVPContext))]
    [Migration("20221222150804_UpdPatientModel")]
    partial class UpdPatientModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SVP.API.Entities.AuthData", b =>
                {
                    b.Property<string>("Login")
                        .HasColumnType("text");

                    b.Property<long?>("DoctorId")
                        .HasColumnType("bigint");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("PatientId")
                        .HasColumnType("bigint");

                    b.HasKey("Login");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("AuthData");
                });

            modelBuilder.Entity("SVP.API.Entities.Doctor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Qualification")
                        .HasColumnType("text")
                        .HasComment("Список квалификаций, описаны через запятую с пробелом");

                    b.HasKey("Id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("SVP.API.Entities.Illness", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("CodeMKB")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Illnesses");
                });

            modelBuilder.Entity("SVP.API.Entities.Patient", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<byte>("Age")
                        .HasColumnType("smallint");

                    b.Property<bool>("Gender")
                        .HasColumnType("boolean")
                        .HasComment("true - М, false - Ж");

                    b.Property<bool>("HasAddiction")
                        .HasColumnType("boolean")
                        .HasComment("Есть ли зависимость");

                    b.Property<long>("IllnessId")
                        .HasColumnType("bigint");

                    b.Property<byte>("LevelAnxiety")
                        .HasColumnType("smallint")
                        .HasComment("Уровень тревоги");

                    b.Property<byte>("LevelAsthenicSyndrome")
                        .HasColumnType("smallint")
                        .HasComment("Уровень астенического синдрома");

                    b.Property<byte>("LevelDepression")
                        .HasColumnType("smallint")
                        .HasComment("Уровень депрессии");

                    b.Property<byte>("LevelHopelessness")
                        .HasColumnType("smallint")
                        .HasComment("Уровень безнадежности");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("NeedHospitalization")
                        .HasColumnType("boolean")
                        .HasComment("Нужна ли госпитализация");

                    b.Property<long?>("RecommendedDoctorId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("IllnessId");

                    b.HasIndex("RecommendedDoctorId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("SVP.API.Entities.AuthData", b =>
                {
                    b.HasOne("SVP.API.Entities.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId");

                    b.HasOne("SVP.API.Entities.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId");

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("SVP.API.Entities.Patient", b =>
                {
                    b.HasOne("SVP.API.Entities.Illness", "Illness")
                        .WithMany()
                        .HasForeignKey("IllnessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SVP.API.Entities.Doctor", "RecommendedDoctor")
                        .WithMany()
                        .HasForeignKey("RecommendedDoctorId");

                    b.Navigation("Illness");

                    b.Navigation("RecommendedDoctor");
                });
#pragma warning restore 612, 618
        }
    }
}
