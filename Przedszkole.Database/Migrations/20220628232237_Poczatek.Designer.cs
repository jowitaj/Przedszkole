// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Przedszkole.Database;

#nullable disable

namespace Przedszkole.Database.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220628232237_Poczatek")]
    partial class Poczatek
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Przedszkole.Database.Models.Dziecko", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RodziceId")
                        .HasColumnType("int");

                    b.Property<int>("WychowawcaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RodziceId");

                    b.HasIndex("WychowawcaId");

                    b.ToTable("Dzieci");
                });

            modelBuilder.Entity("Przedszkole.Database.Models.Obecnosc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("DzieckoId")
                        .HasColumnType("int");

                    b.Property<bool>("Obecny")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("DzieckoId");

                    b.ToTable("Obecnosci");
                });

            modelBuilder.Entity("Przedszkole.Database.Models.Rodzice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ImieMatki")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImieOjca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NazwiskoMatki")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NazwiskoOjca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rodzice");
                });

            modelBuilder.Entity("Przedszkole.Database.Models.Wychowawca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Wychowawcy");
                });

            modelBuilder.Entity("Przedszkole.Database.Models.Dziecko", b =>
                {
                    b.HasOne("Przedszkole.Database.Models.Rodzice", "Rodzice")
                        .WithMany()
                        .HasForeignKey("RodziceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Przedszkole.Database.Models.Wychowawca", "Wychowawca")
                        .WithMany()
                        .HasForeignKey("WychowawcaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rodzice");

                    b.Navigation("Wychowawca");
                });

            modelBuilder.Entity("Przedszkole.Database.Models.Obecnosc", b =>
                {
                    b.HasOne("Przedszkole.Database.Models.Dziecko", "Dziecko")
                        .WithMany()
                        .HasForeignKey("DzieckoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dziecko");
                });
#pragma warning restore 612, 618
        }
    }
}
