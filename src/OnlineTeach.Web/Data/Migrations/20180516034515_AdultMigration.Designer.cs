﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using OnlineTeach.Web.Data;
using OnlineTeach.Web.Data.Cource;
using System;

namespace OnlineTeach.Web.Data.Migrations
{
    [DbContext(typeof(AdultDbContext))]
    [Migration("20180516034515_AdultMigration")]
    partial class AdultMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OnlineTeach.Web.Data.Adult.TeacherApply", b =>
                {
                    b.Property<long>("key")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ApplyCount");

                    b.Property<string>("ApplyReason");

                    b.Property<int>("ApplyStatus");

                    b.Property<DateTime>("ApplyTime");

                    b.Property<string>("Name");

                    b.Property<string>("RealName");

                    b.Property<string>("School");

                    b.HasKey("key");

                    b.ToTable("TeacherApplies");
                });

            modelBuilder.Entity("OnlineTeach.Web.Data.Cource.CourceItem", b =>
                {
                    b.Property<long>("key")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BookCount");

                    b.Property<string>("Content");

                    b.Property<DateTime>("EndTime");

                    b.Property<int>("Grade");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Name");

                    b.Property<double>("Price");

                    b.Property<DateTime>("StartTime");

                    b.Property<int>("State");

                    b.Property<string>("TeacherName");

                    b.HasKey("key");

                    b.ToTable("CourceItems");
                });

            modelBuilder.Entity("OnlineTeach.Web.Data.Cource.CourceOutLine", b =>
                {
                    b.Property<long>("key")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("CourceId");

                    b.Property<int>("LearnStatu");

                    b.Property<string>("OUtlineName");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("TeacherName");

                    b.HasKey("key");

                    b.HasIndex("CourceId");

                    b.ToTable("courceOutLines");
                });

            modelBuilder.Entity("OnlineTeach.Web.Data.Cource.CourceOutLine", b =>
                {
                    b.HasOne("OnlineTeach.Web.Data.Cource.CourceItem", "CourceItem")
                        .WithMany("CourceOutLines")
                        .HasForeignKey("CourceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}