﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RehberUygulamasi.Models;

namespace RehberUygulamasi.Migrations
{
    [DbContext(typeof(RehberContext))]
    [Migration("20210202141101_RehberUygulamasiGuncel")]
    partial class RehberUygulamasiGuncel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("RehberUygulamasi.Models.Kisi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Ad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Adres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAdres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EvTelefon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IsTelefon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SehirId")
                        .HasColumnType("int");

                    b.Property<string>("Soyad")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SehirId");

                    b.ToTable("Kisiler");
                });

            modelBuilder.Entity("RehberUygulamasi.Models.Sehir", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("SehirAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SehirKodu")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Şehirler");
                });

            modelBuilder.Entity("RehberUygulamasi.Models.Kisi", b =>
                {
                    b.HasOne("RehberUygulamasi.Models.Sehir", "Sehir")
                        .WithMany()
                        .HasForeignKey("SehirId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sehir");
                });
#pragma warning restore 612, 618
        }
    }
}
