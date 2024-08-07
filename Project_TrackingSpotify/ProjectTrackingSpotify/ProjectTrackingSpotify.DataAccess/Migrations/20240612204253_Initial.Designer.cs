﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectTrackingSpotify.DataAccess.Data;

#nullable disable

namespace ProjectTrackingSpotify.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240612204253_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Image", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ImageId"));

                    b.Property<int?>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("height")
                        .HasColumnType("int");

                    b.Property<string>("url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("width")
                        .HasColumnType("int");

                    b.HasKey("ImageId");

                    b.HasIndex("ItemId");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemId"));

                    b.Property<int?>("TopItemsId")
                        .HasColumnType("int");

                    b.Property<string>("href")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("popularity")
                        .HasColumnType("int");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("uri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ItemId");

                    b.HasIndex("TopItemsId");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("ProjectTrackingSpotify.Models.TokenResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccessToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "access_token");

                    b.Property<int>("ExpiresIn")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "expires_in");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "refresh_token");

                    b.Property<string>("Scope")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "scope");

                    b.Property<string>("TokenType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "token_type");

                    b.HasKey("Id");

                    b.ToTable("TokenResults");
                });

            modelBuilder.Entity("ProjectTrackingSpotify.Models.UrlSpotify", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UrlSpotify");
                });

            modelBuilder.Entity("TopItems", b =>
                {
                    b.Property<int>("TopItemsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TopItemsId"));

                    b.Property<string>("href")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("limit")
                        .HasColumnType("int");

                    b.Property<string>("next")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("offset")
                        .HasColumnType("int");

                    b.Property<string>("previous")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("total")
                        .HasColumnType("int");

                    b.HasKey("TopItemsId");

                    b.ToTable("TopItems");
                });

            modelBuilder.Entity("Image", b =>
                {
                    b.HasOne("Item", null)
                        .WithMany("images")
                        .HasForeignKey("ItemId");
                });

            modelBuilder.Entity("Item", b =>
                {
                    b.HasOne("TopItems", null)
                        .WithMany("itemsList")
                        .HasForeignKey("TopItemsId");
                });

            modelBuilder.Entity("Item", b =>
                {
                    b.Navigation("images");
                });

            modelBuilder.Entity("TopItems", b =>
                {
                    b.Navigation("itemsList");
                });
#pragma warning restore 612, 618
        }
    }
}
