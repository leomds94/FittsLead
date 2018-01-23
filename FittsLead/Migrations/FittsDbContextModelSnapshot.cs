﻿// <auto-generated />
using FittsLead.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace FittsLead.Migrations
{
    [DbContext(typeof(FittsDbContext))]
    partial class FittsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("FittsLead.Models.ClickedPoint", b =>
                {
                    b.Property<int>("ClickedPointId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FittsObjectId");

                    b.Property<string>("Time");

                    b.Property<int>("X");

                    b.Property<int>("Y");

                    b.HasKey("ClickedPointId");

                    b.HasIndex("FittsObjectId")
                        .IsUnique();

                    b.ToTable("ClickedPoints");
                });

            modelBuilder.Entity("FittsLead.Models.ClipRectangle", b =>
                {
                    b.Property<int>("ClipRectangleId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FittsObjectId");

                    b.Property<int>("Height");

                    b.Property<int>("Width");

                    b.Property<int>("X");

                    b.Property<int>("Y");

                    b.HasKey("ClipRectangleId");

                    b.HasIndex("FittsObjectId")
                        .IsUnique();

                    b.ToTable("ClipRectangles");
                });

            modelBuilder.Entity("FittsLead.Models.FittsObject", b =>
                {
                    b.Property<int>("FittsObjectId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("UserId");

                    b.HasKey("FittsObjectId");

                    b.HasIndex("UserId");

                    b.ToTable("FittsObjects");
                });

            modelBuilder.Entity("FittsLead.Models.FittsUser", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Device");

                    b.Property<int>("StageCount");

                    b.HasKey("UserId");

                    b.ToTable("FittsUsers");
                });

            modelBuilder.Entity("FittsLead.Models.Point", b =>
                {
                    b.Property<int>("PointId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClickedPointId");

                    b.Property<int>("Time");

                    b.Property<int>("X");

                    b.Property<int>("Y");

                    b.HasKey("PointId");

                    b.HasIndex("ClickedPointId");

                    b.ToTable("Points");
                });

            modelBuilder.Entity("FittsLead.Models.StageThreshold", b =>
                {
                    b.Property<int>("StageThresholdId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("UserId");

                    b.Property<int>("Value");

                    b.HasKey("StageThresholdId");

                    b.HasIndex("UserId");

                    b.ToTable("StageThresholders");
                });

            modelBuilder.Entity("FittsLead.Models.ClickedPoint", b =>
                {
                    b.HasOne("FittsLead.Models.FittsObject", "FittsObject")
                        .WithOne("ClickedPoint")
                        .HasForeignKey("FittsLead.Models.ClickedPoint", "FittsObjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FittsLead.Models.ClipRectangle", b =>
                {
                    b.HasOne("FittsLead.Models.FittsObject", "FittsObject")
                        .WithOne("ClipRectangle")
                        .HasForeignKey("FittsLead.Models.ClipRectangle", "FittsObjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FittsLead.Models.FittsObject", b =>
                {
                    b.HasOne("FittsLead.Models.FittsUser", "FittsUser")
                        .WithMany("FittsObjects")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FittsLead.Models.Point", b =>
                {
                    b.HasOne("FittsLead.Models.ClickedPoint", "ClickedPoint")
                        .WithMany("Trajectory")
                        .HasForeignKey("ClickedPointId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FittsLead.Models.StageThreshold", b =>
                {
                    b.HasOne("FittsLead.Models.FittsUser", "FittsUser")
                        .WithMany("StageThreshold")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
