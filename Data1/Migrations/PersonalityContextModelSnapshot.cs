﻿// <auto-generated />
using Data1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Data1.Migrations
{
    [DbContext(typeof(PersonalityContext))]
    partial class PersonalityContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data1.ParagraphEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ParagraphText");

                    b.Property<int>("TypeId");

                    b.HasKey("Id");

                    b.ToTable("Paragraphs");
                });

            modelBuilder.Entity("Data1.TraitEntity", b =>
                {
                    b.Property<string>("Id");

                    b.Property<decimal>("MinVal");

                    b.Property<decimal>("MaxVal");

                    b.Property<string>("Text");

                    b.HasKey("Id", "MinVal", "MaxVal");

                    b.ToTable("Traits");
                });
#pragma warning restore 612, 618
        }
    }
}
