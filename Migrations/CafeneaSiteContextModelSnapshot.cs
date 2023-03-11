﻿// <auto-generated />
using System;
using CafeneaSite.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CafeneaSite.Migrations
{
    [DbContext(typeof(CafeneaSiteContext))]
    partial class CafeneaSiteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int?>("TipBoabeID")
                        .HasColumnType("int");

                    b.Property<int?>("TipCafeaID")
                        .HasColumnType("int");

                    b.Property<int?>("TipLapteID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TipBoabeID");

                    b.HasIndex("TipCafeaID");

                    b.HasIndex("TipLapteID");

                    b.ToTable("Cafea");
                });

            modelBuilder.Entity("CafeneaSite.Models.TipBoabe", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("DenumireBoabe")
                        .IsRequired()
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

                    b.Property<string>("Tip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("TipLapte");
                });

            modelBuilder.Entity("CafeneaSite.Models.Cafea", b =>
                {
                    b.HasOne("CafeneaSite.Models.TipBoabe", "TipBoabe")
                        .WithMany("Cafele")
                        .HasForeignKey("TipBoabeID");

                    b.HasOne("CafeneaSite.Models.TipCafea", "TipCafea")
                        .WithMany("Cafele")
                        .HasForeignKey("TipCafeaID");

                    b.HasOne("CafeneaSite.Models.TipLapte", "TipLapte")
                        .WithMany("Cafele")
                        .HasForeignKey("TipLapteID");

                    b.Navigation("TipBoabe");

                    b.Navigation("TipCafea");

                    b.Navigation("TipLapte");
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
#pragma warning restore 612, 618
        }
    }
}
