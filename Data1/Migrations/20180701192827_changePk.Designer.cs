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
    [Migration("20180701192827_changePk")]
    partial class changePk
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data1.CompanyEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("ShortDescription");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Data1.ParagraphEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ParagraphText");

                    b.Property<int>("TypeId");

                    b.HasKey("Id");

                    b.ToTable("Paragraphs");
                });

            modelBuilder.Entity("Data1.ProfileEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Analysis");

                    b.Property<string>("CompanyId");

                    b.Property<string>("UserMail");

                    b.HasKey("Id");

                    b.ToTable("Profiles");
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

            modelBuilder.Entity("Data1.UserEntity", b =>
                {
                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.HasKey("Email");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
