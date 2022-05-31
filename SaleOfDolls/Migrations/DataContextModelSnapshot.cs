﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SaleOfDolls.Data;

#nullable disable

namespace SaleOfDolls.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SaleOfDolls.Models.Address", b =>
                {
                    b.Property<long>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("AddressId"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.HasKey("AddressId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("SaleOfDolls.Models.Client", b =>
                {
                    b.Property<long>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ClientId"), 1L, 1);

                    b.Property<long?>("AddressId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("TaxNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("ClientId");

                    b.HasIndex("AddressId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("SaleOfDolls.Models.Doll", b =>
                {
                    b.Property<long>("DollId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("DollId"), 1L, 1);

                    b.Property<byte>("Accessory")
                        .HasColumnType("tinyint");

                    b.Property<byte>("Clothing")
                        .HasColumnType("tinyint");

                    b.Property<byte>("Eyes")
                        .HasColumnType("tinyint");

                    b.Property<int>("Hair")
                        .HasColumnType("int");

                    b.Property<byte>("Skin")
                        .HasColumnType("tinyint");

                    b.HasKey("DollId");

                    b.ToTable("Dolls");
                });

            modelBuilder.Entity("SaleOfDolls.Models.Solicitation", b =>
                {
                    b.Property<long>("SolicitationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("SolicitationId"), 1L, 1);

                    b.Property<long>("ClientId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("date");

                    b.Property<long?>("DollId")
                        .HasColumnType("bigint");

                    b.Property<byte>("FormOfPayment")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("date");

                    b.Property<long>("RequestNumber")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(15,2)");

                    b.HasKey("SolicitationId");

                    b.HasIndex("ClientId");

                    b.HasIndex("DollId");

                    b.ToTable("Solicitations");
                });

            modelBuilder.Entity("SaleOfDolls.Models.Client", b =>
                {
                    b.HasOne("SaleOfDolls.Models.Address", null)
                        .WithMany("Client")
                        .HasForeignKey("AddressId");
                });

            modelBuilder.Entity("SaleOfDolls.Models.Solicitation", b =>
                {
                    b.HasOne("SaleOfDolls.Models.Client", "Client")
                        .WithMany("Solicitation")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SaleOfDolls.Models.Doll", null)
                        .WithMany("Solicitation")
                        .HasForeignKey("DollId");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("SaleOfDolls.Models.Address", b =>
                {
                    b.Navigation("Client");
                });

            modelBuilder.Entity("SaleOfDolls.Models.Client", b =>
                {
                    b.Navigation("Solicitation");
                });

            modelBuilder.Entity("SaleOfDolls.Models.Doll", b =>
                {
                    b.Navigation("Solicitation");
                });
#pragma warning restore 612, 618
        }
    }
}
