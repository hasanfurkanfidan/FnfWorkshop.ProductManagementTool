﻿// <auto-generated />
using System;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(ProductContext))]
    [Migration("20210131193005_DatabaseInitializing")]
    partial class DatabaseInitializing
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Enities.Concrete.Application", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AppName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("Enities.Concrete.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ApplicationId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParentCategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("ParentGategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("ParentGategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Enities.Concrete.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ApplicationId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Enities.Concrete.ProductTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ApplicationId")
                        .HasColumnType("int");

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductTags");
                });

            modelBuilder.Entity("Enities.Concrete.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ApplicaitonId")
                        .HasColumnType("int");

                    b.Property<int?>("ApplicationId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("VariationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("ProductId");

                    b.HasIndex("VariationId");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("Enities.Concrete.Variation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ApplicationId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("VariationTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("ProductId");

                    b.HasIndex("VariationTypeId");

                    b.ToTable("Variations");
                });

            modelBuilder.Entity("Enities.Concrete.VariationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ApplicationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.ToTable("VariationTypes");
                });

            modelBuilder.Entity("Enities.Concrete.Category", b =>
                {
                    b.HasOne("Enities.Concrete.Application", "Application")
                        .WithMany("Categories")
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Enities.Concrete.Category", "ParentGategory")
                        .WithMany()
                        .HasForeignKey("ParentGategoryId");

                    b.Navigation("Application");

                    b.Navigation("ParentGategory");
                });

            modelBuilder.Entity("Enities.Concrete.Product", b =>
                {
                    b.HasOne("Enities.Concrete.Application", "Application")
                        .WithMany("Products")
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Enities.Concrete.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Application");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Enities.Concrete.ProductTag", b =>
                {
                    b.HasOne("Enities.Concrete.Application", "Application")
                        .WithMany("ProductTags")
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Enities.Concrete.Product", "Product")
                        .WithMany("ProductTags")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Application");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Enities.Concrete.Stock", b =>
                {
                    b.HasOne("Enities.Concrete.Application", "Application")
                        .WithMany("Stocks")
                        .HasForeignKey("ApplicationId");

                    b.HasOne("Enities.Concrete.Product", "Product")
                        .WithMany("Stocks")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Enities.Concrete.Variation", "Variation")
                        .WithMany("Stocks")
                        .HasForeignKey("VariationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Application");

                    b.Navigation("Product");

                    b.Navigation("Variation");
                });

            modelBuilder.Entity("Enities.Concrete.Variation", b =>
                {
                    b.HasOne("Enities.Concrete.Application", "Application")
                        .WithMany("Variations")
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Enities.Concrete.Product", "Product")
                        .WithMany("Variations")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Enities.Concrete.VariationType", "VariationType")
                        .WithMany("Variations")
                        .HasForeignKey("VariationTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Application");

                    b.Navigation("Product");

                    b.Navigation("VariationType");
                });

            modelBuilder.Entity("Enities.Concrete.VariationType", b =>
                {
                    b.HasOne("Enities.Concrete.Application", "Application")
                        .WithMany("VariationTypes")
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Application");
                });

            modelBuilder.Entity("Enities.Concrete.Application", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("Products");

                    b.Navigation("ProductTags");

                    b.Navigation("Stocks");

                    b.Navigation("Variations");

                    b.Navigation("VariationTypes");
                });

            modelBuilder.Entity("Enities.Concrete.Product", b =>
                {
                    b.Navigation("ProductTags");

                    b.Navigation("Stocks");

                    b.Navigation("Variations");
                });

            modelBuilder.Entity("Enities.Concrete.Variation", b =>
                {
                    b.Navigation("Stocks");
                });

            modelBuilder.Entity("Enities.Concrete.VariationType", b =>
                {
                    b.Navigation("Variations");
                });
#pragma warning restore 612, 618
        }
    }
}