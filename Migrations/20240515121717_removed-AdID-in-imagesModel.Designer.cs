﻿// <auto-generated />
using System;
using FogelFormedlingenAB.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FogelFormedlingenAB.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240515121717_removed-AdID-in-imagesModel")]
    partial class removedAdIDinimagesModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FogelFormedlingenAB.Models.Account", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("OpenIDIssuer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OpenIDSubject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phonenumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("ID");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("FogelFormedlingenAB.Models.Ad", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("AccountID")
                        .HasColumnType("int");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("ImageID")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("ID");

                    b.HasIndex("AccountID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("ImageID");

                    b.ToTable("Ads");
                });

            modelBuilder.Entity("FogelFormedlingenAB.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("FogelFormedlingenAB.Models.Favourite", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("AccountID")
                        .HasColumnType("int");

                    b.Property<int>("AdID")
                        .HasColumnType("int");

                    b.Property<int?>("AdID1")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AccountID");

                    b.HasIndex("AdID");

                    b.HasIndex("AdID1")
                        .IsUnique()
                        .HasFilter("[AdID1] IS NOT NULL");

                    b.ToTable("Favourites");
                });

            modelBuilder.Entity("FogelFormedlingenAB.Models.Image", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("FogelFormedlingenAB.Models.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<int>("AdID")
                        .HasColumnType("int");

                    b.Property<int?>("AdID1")
                        .HasColumnType("int");

                    b.Property<DateTime>("BoughtDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("AccountId");

                    b.HasIndex("AdID");

                    b.HasIndex("AdID1")
                        .IsUnique()
                        .HasFilter("[AdID1] IS NOT NULL");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("FogelFormedlingenAB.Models.Reported", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("AccountID")
                        .HasColumnType("int");

                    b.Property<int?>("AdID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("ReportedByID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AccountID");

                    b.HasIndex("AdID");

                    b.ToTable("reports", t =>
                        {
                            t.HasCheckConstraint("CK_MyEntity_OneColumnOnly", "(AccountID IS NOT NULL AND AdID IS NULL) OR (AccountID IS NULL AND AdID IS NOT NULL)");
                        });
                });

            modelBuilder.Entity("FogelFormedlingenAB.Models.Ad", b =>
                {
                    b.HasOne("FogelFormedlingenAB.Models.Account", "Account")
                        .WithMany("Ads")
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FogelFormedlingenAB.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FogelFormedlingenAB.Models.Image", "Image")
                        .WithMany("Ad")
                        .HasForeignKey("ImageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Category");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("FogelFormedlingenAB.Models.Favourite", b =>
                {
                    b.HasOne("FogelFormedlingenAB.Models.Account", "Account")
                        .WithMany("Favourites")
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FogelFormedlingenAB.Models.Ad", "Ad")
                        .WithMany()
                        .HasForeignKey("AdID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FogelFormedlingenAB.Models.Ad", null)
                        .WithOne("Favourite")
                        .HasForeignKey("FogelFormedlingenAB.Models.Favourite", "AdID1");

                    b.Navigation("Account");

                    b.Navigation("Ad");
                });

            modelBuilder.Entity("FogelFormedlingenAB.Models.Order", b =>
                {
                    b.HasOne("FogelFormedlingenAB.Models.Account", "Account")
                        .WithMany("Orders")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FogelFormedlingenAB.Models.Ad", "Ad")
                        .WithMany()
                        .HasForeignKey("AdID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FogelFormedlingenAB.Models.Ad", null)
                        .WithOne("Order")
                        .HasForeignKey("FogelFormedlingenAB.Models.Order", "AdID1");

                    b.Navigation("Account");

                    b.Navigation("Ad");
                });

            modelBuilder.Entity("FogelFormedlingenAB.Models.Reported", b =>
                {
                    b.HasOne("FogelFormedlingenAB.Models.Account", "Account")
                        .WithMany("Reports")
                        .HasForeignKey("AccountID");

                    b.HasOne("FogelFormedlingenAB.Models.Ad", "Ad")
                        .WithMany()
                        .HasForeignKey("AdID");

                    b.Navigation("Account");

                    b.Navigation("Ad");
                });

            modelBuilder.Entity("FogelFormedlingenAB.Models.Account", b =>
                {
                    b.Navigation("Ads");

                    b.Navigation("Favourites");

                    b.Navigation("Orders");

                    b.Navigation("Reports");
                });

            modelBuilder.Entity("FogelFormedlingenAB.Models.Ad", b =>
                {
                    b.Navigation("Favourite");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("FogelFormedlingenAB.Models.Image", b =>
                {
                    b.Navigation("Ad");
                });
#pragma warning restore 612, 618
        }
    }
}
