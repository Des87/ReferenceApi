﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReferenceApi;

#nullable disable

namespace ReferenceApi.Migrations
{
    [DbContext(typeof(ContextDb))]
    partial class ContextDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.7");

            modelBuilder.Entity("ReferenceApi.Models.Condition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int?>("Code")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Icon")
                        .HasColumnType("TEXT");

                    b.Property<string>("Text")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Condition");
                });

            modelBuilder.Entity("ReferenceApi.Models.Current", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Cloud")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ConditionId")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Feelslike_c")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Feelslike_f")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Gust_kph")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Gust_mph")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Humidity")
                        .HasColumnType("TEXT");

                    b.Property<string>("Is_day")
                        .HasColumnType("TEXT");

                    b.Property<string>("Last_updated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Last_updated_epoch")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Precip_in")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Precip_mm")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Pressure_in")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Pressure_mb")
                        .HasColumnType("TEXT");

                    b.Property<string>("Temp_c")
                        .HasColumnType("TEXT");

                    b.Property<string>("Temp_f")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Uv")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Vis_km")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Vis_miles")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Wind_degree")
                        .HasColumnType("TEXT");

                    b.Property<string>("Wind_dir")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Wind_kph")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Wind_mph")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ConditionId");

                    b.ToTable("Current");
                });

            modelBuilder.Entity("ReferenceApi.Models.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Lat")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Localtime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Localtime_epoch")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Lon")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Region")
                        .HasColumnType("TEXT");

                    b.Property<string>("Tz_id")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("ReferenceApi.Models.Weather", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("CurrentId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("LocationId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CurrentId");

                    b.HasIndex("LocationId");

                    b.ToTable("Weather");
                });

            modelBuilder.Entity("ReferenceApi.Models.Current", b =>
                {
                    b.HasOne("ReferenceApi.Models.Condition", "Condition")
                        .WithMany()
                        .HasForeignKey("ConditionId");

                    b.Navigation("Condition");
                });

            modelBuilder.Entity("ReferenceApi.Models.Weather", b =>
                {
                    b.HasOne("ReferenceApi.Models.Current", "Current")
                        .WithMany()
                        .HasForeignKey("CurrentId");

                    b.HasOne("ReferenceApi.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.Navigation("Current");

                    b.Navigation("Location");
                });
#pragma warning restore 612, 618
        }
    }
}
