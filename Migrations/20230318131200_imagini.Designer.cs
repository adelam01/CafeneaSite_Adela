﻿// <auto-generated />
using System;
using CafeneaSite.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CafeneaSite.Migrations
{
    [DbContext(typeof(CafeneaSiteContext))]
    [Migration("20230318131200_imagini")]
    partial class imagini
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CafeneaSite.Models.Cafea", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("DenumireCafea")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Pret")
                        .HasColumnType("decimal(6,2)");

                    b.Property<int?>("TipAromaID")
                        .HasColumnType("int");

                    b.Property<int?>("TipBoabeID")
                        .HasColumnType("int");

                    b.Property<int?>("TipCafeaID")
                        .HasColumnType("int");

                    b.Property<int?>("TipLapteID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TipAromaID");

                    b.HasIndex("TipBoabeID");

                    b.HasIndex("TipCafeaID");

                    b.HasIndex("TipLapteID");

                    b.ToTable("Cafea");
                });

            modelBuilder.Entity("CafeneaSite.Models.CafeaTipuriTopping", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("CafeaID")
                        .HasColumnType("int");

                    b.Property<int>("TipToppingID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CafeaID");

                    b.HasIndex("TipToppingID");

                    b.ToTable("CafeaTipuriTopping");
                });

            modelBuilder.Entity("CafeneaSite.Models.Membru", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Nume")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Prenume")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Membru");
                });

            modelBuilder.Entity("CafeneaSite.Models.TipAroma", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("DenumireAroma")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("Imagine")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("TipAroma");
                });

            modelBuilder.Entity("CafeneaSite.Models.TipBoabe", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("DenumireBoabe")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("Imagine")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("TipBoabe");
                });

            modelBuilder.Entity("CafeneaSite.Models.TipCafea", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Imagine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tip")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.HasKey("ID");

                    b.ToTable("TipCafea");
                });

            modelBuilder.Entity("CafeneaSite.Models.TipLapte", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("DenumireLapte")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("Imagine")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("TipLapte");
                });

            modelBuilder.Entity("CafeneaSite.Models.TipTopping", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("DenumireTopping")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("Imagine")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("TipTopping");
                });

            modelBuilder.Entity("CafeneaSite.Models.Cafea", b =>
                {
                    b.HasOne("CafeneaSite.Models.TipAroma", "TipAroma")
                        .WithMany("Cafele")
                        .HasForeignKey("TipAromaID");

                    b.HasOne("CafeneaSite.Models.TipBoabe", "TipBoabe")
                        .WithMany("Cafele")
                        .HasForeignKey("TipBoabeID");

                    b.HasOne("CafeneaSite.Models.TipCafea", "TipCafea")
                        .WithMany("Cafele")
                        .HasForeignKey("TipCafeaID");

                    b.HasOne("CafeneaSite.Models.TipLapte", "TipLapte")
                        .WithMany("Cafele")
                        .HasForeignKey("TipLapteID");

                    b.Navigation("TipAroma");

                    b.Navigation("TipBoabe");

                    b.Navigation("TipCafea");

                    b.Navigation("TipLapte");
                });

            modelBuilder.Entity("CafeneaSite.Models.CafeaTipuriTopping", b =>
                {
                    b.HasOne("CafeneaSite.Models.Cafea", "Cafea")
                        .WithMany("CafeaTipuriTopping")
                        .HasForeignKey("CafeaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CafeneaSite.Models.TipTopping", "TipTopping")
                        .WithMany("CafeaTipuriTopping")
                        .HasForeignKey("TipToppingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cafea");

                    b.Navigation("TipTopping");
                });

            modelBuilder.Entity("CafeneaSite.Models.Cafea", b =>
                {
                    b.Navigation("CafeaTipuriTopping");
                });

            modelBuilder.Entity("CafeneaSite.Models.TipAroma", b =>
                {
                    b.Navigation("Cafele");
                });

            modelBuilder.Entity("CafeneaSite.Models.TipBoabe", b =>
                {
                    b.Navigation("Cafele");
                });

            modelBuilder.Entity("CafeneaSite.Models.TipCafea", b =>
                {
                    b.Navigation("Cafele");
                });

            modelBuilder.Entity("CafeneaSite.Models.TipLapte", b =>
                {
                    b.Navigation("Cafele");
                });

            modelBuilder.Entity("CafeneaSite.Models.TipTopping", b =>
                {
                    b.Navigation("CafeaTipuriTopping");
                });
#pragma warning restore 612, 618
        }
    }
}
