﻿// <auto-generated />
using System;
using EMS.TrafficRecordService.DAL.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EMS.TrafficRecordService.gRPC.Migrations
{
    [DbContext(typeof(TrafficContext))]
    [Migration("20230327132405_Init_Db")]
    partial class Init_Db
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EMS.TrafficRecordService.DAL.Database.Entities.Traffic", b =>
                {
                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("TrafficDate")
                        .HasColumnType("datetime2");

                    b.ToTable("Traffics");
                });
#pragma warning restore 612, 618
        }
    }
}