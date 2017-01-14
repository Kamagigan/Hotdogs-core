﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using HotDogsWeb.Context;

namespace HotDogsWeb.Migrations
{
    [DbContext(typeof(HotDogContext))]
    partial class HotDogContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("HotDogsWeb.Models.HotDog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Available");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Description");

                    b.Property<int?>("HotDogStoreId");

                    b.Property<string>("Name");

                    b.Property<int>("PrepTime");

                    b.Property<int>("Price");

                    b.HasKey("Id");

                    b.HasIndex("HotDogStoreId");

                    b.ToTable("HotDogs");
                });

            modelBuilder.Entity("HotDogsWeb.Models.HotDogStore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Latitude");

                    b.Property<string>("Location");

                    b.Property<double>("Longitude");

                    b.Property<string>("ManagerName");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("HotDogsWeb.Models.HotDog", b =>
                {
                    b.HasOne("HotDogsWeb.Models.HotDogStore")
                        .WithMany("HotDogs")
                        .HasForeignKey("HotDogStoreId");
                });
        }
    }
}
