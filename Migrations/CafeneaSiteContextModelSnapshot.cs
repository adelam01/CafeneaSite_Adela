﻿// <auto-generated />
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

                    b.Property<int>("TipCafeaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TipCafeaID");

                    b.ToTable("Cafea");
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

            modelBuilder.Entity("CafeneaSite.Models.Cafea", b =>
                {
                    b.HasOne("CafeneaSite.Models.TipCafea", "TipCafea")
                        .WithMany("Cafele")
                        .HasForeignKey("TipCafeaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipCafea");
                });

            modelBuilder.Entity("CafeneaSite.Models.TipCafea", b =>
                {
                    b.Navigation("Cafele");
                });
#pragma warning restore 612, 618
        }
    }
}
