﻿// <auto-generated />
using System;
using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Database.Migrations
{
    [DbContext(typeof(LocalizerContext))]
    partial class LocalizerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Database.Entities.Measurement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CapturedAtUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CapturedById")
                        .IsRequired()
                        .HasColumnType("character varying(24)");

                    b.Property<string>("DeviceUid")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<int>("Rssi")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CapturedById");

                    b.ToTable("Measurements");
                });

            modelBuilder.Entity("Database.Entities.Sensor", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(24)
                        .HasColumnType("character varying(24)");

                    b.Property<string>("DeviceType")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Sensors");
                });

            modelBuilder.Entity("Database.Entities.Measurement", b =>
                {
                    b.HasOne("Database.Entities.Sensor", "CapturedBy")
                        .WithMany()
                        .HasForeignKey("CapturedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CapturedBy");
                });
#pragma warning restore 612, 618
        }
    }
}
