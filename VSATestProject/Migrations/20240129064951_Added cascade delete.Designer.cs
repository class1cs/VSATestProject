﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using VSATestProject.Data_Access_Layer;

#nullable disable

namespace VSATestProject.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240129064951_Added cascade delete")]
    partial class Addedcascadedelete
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("VSATestProject.Entities.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("character varying(13)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Accounts");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Account");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("VSATestProject.Entities.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("VSATestProject.Entities.BookProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uuid");

                    b.Property<long>("Count")
                        .HasColumnType("bigint");

                    b.Property<Guid?>("PurchaseId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("PurchaseId");

                    b.ToTable("BookProducts");
                });

            modelBuilder.Entity("VSATestProject.Entities.Purchase", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("numeric");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("VSATestProject.Entities.UserSession", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("UserSessions");
                });

            modelBuilder.Entity("VSATestProject.Entities.Administrator", b =>
                {
                    b.HasBaseType("VSATestProject.Entities.Account");

                    b.HasDiscriminator().HasValue("Administrator");

                    b.HasData(
                        new
                        {
                            Id = new Guid("44d6884f-bb9a-4309-b2f5-38c9231909df"),
                            Login = "admin",
                            PasswordHash = "ISMvKXpXpadDiUoOSoAfww=="
                        });
                });

            modelBuilder.Entity("VSATestProject.Entities.User", b =>
                {
                    b.HasBaseType("VSATestProject.Entities.Account");

                    b.Property<decimal>("Balance")
                        .HasColumnType("numeric");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("User");
                });

            modelBuilder.Entity("VSATestProject.Entities.BookProduct", b =>
                {
                    b.HasOne("VSATestProject.Entities.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VSATestProject.Entities.Purchase", null)
                        .WithMany("BookPurchases")
                        .HasForeignKey("PurchaseId");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("VSATestProject.Entities.Purchase", b =>
                {
                    b.HasOne("VSATestProject.Entities.User", null)
                        .WithMany("Purchases")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("VSATestProject.Entities.UserSession", b =>
                {
                    b.HasOne("VSATestProject.Entities.Account", null)
                        .WithMany("Sessions")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VSATestProject.Entities.Account", b =>
                {
                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("VSATestProject.Entities.Purchase", b =>
                {
                    b.Navigation("BookPurchases");
                });

            modelBuilder.Entity("VSATestProject.Entities.User", b =>
                {
                    b.Navigation("Purchases");
                });
#pragma warning restore 612, 618
        }
    }
}
