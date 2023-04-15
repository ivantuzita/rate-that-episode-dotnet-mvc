﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RateThatEpisode.Data;

#nullable disable

namespace RateThatEpisode.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("RateThatEpisode.Models.Episode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<double>("Rating")
                        .HasColumnType("double");

                    b.Property<int>("SeriesID")
                        .HasColumnType("int");

                    b.Property<string>("Synopsys")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("SeriesID");

                    b.ToTable("Episodes");
                });

            modelBuilder.Entity("RateThatEpisode.Models.Series", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateOnly>("DebutYear")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("NumberOfEpisodes")
                        .HasColumnType("int");

                    b.Property<double>("OverallRating")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Series");
                });

            modelBuilder.Entity("RateThatEpisode.Models.Episode", b =>
                {
                    b.HasOne("RateThatEpisode.Models.Series", "Series")
                        .WithMany("Episodes")
                        .HasForeignKey("SeriesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Series");
                });

            modelBuilder.Entity("RateThatEpisode.Models.Series", b =>
                {
                    b.Navigation("Episodes");
                });
#pragma warning restore 612, 618
        }
    }
}
