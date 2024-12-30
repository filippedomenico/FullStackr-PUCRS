﻿// <auto-generated />
using System;
using HealthPass.API.Persistencia.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HealthPass.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210426000331_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("HealthPass.API.Entidades.Usuario", b =>
                {
                    b.Property<Guid>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("Genero")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Passaporte")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("TEXT");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("HealthPass.API.Entidades.UsuarioDoseVacina", b =>
                {
                    b.Property<Guid>("UsuarioDoseVacinaId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataPrevisaoDose")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DataVacinacao")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UsuarioVacinaId")
                        .HasColumnType("TEXT");

                    b.HasKey("UsuarioDoseVacinaId");

                    b.ToTable("UsuarioDoseVacina");
                });

            modelBuilder.Entity("HealthPass.API.Entidades.UsuarioVacina", b =>
                {
                    b.Property<Guid>("UsuarioVacinaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("VacinaId")
                        .HasColumnType("TEXT");

                    b.HasKey("UsuarioVacinaId");

                    b.HasIndex("UsuarioId");

                    b.HasIndex("VacinaId");

                    b.ToTable("UsuarioVacina");
                });

            modelBuilder.Entity("HealthPass.API.Entidades.Vacina", b =>
                {
                    b.Property<Guid>("VacinaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Disponivel")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DosesNecessarias")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("TipoVacina")
                        .HasColumnType("int");

                    b.HasKey("VacinaId");

                    b.ToTable("Vacina");
                });

            modelBuilder.Entity("HealthPass.API.Entidades.UsuarioDoseVacina", b =>
                {
                    b.HasOne("HealthPass.API.Entidades.UsuarioVacina", "UsuarioVacina")
                        .WithMany("UsuarioDosesVacina")
                        .HasForeignKey("UsuarioDoseVacinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UsuarioVacina");
                });

            modelBuilder.Entity("HealthPass.API.Entidades.UsuarioVacina", b =>
                {
                    b.HasOne("HealthPass.API.Entidades.Usuario", "Usuario")
                        .WithMany("UsuarioVacinas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthPass.API.Entidades.Vacina", "Vacina")
                        .WithMany("UsuarioVacinas")
                        .HasForeignKey("VacinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");

                    b.Navigation("Vacina");
                });

            modelBuilder.Entity("HealthPass.API.Entidades.Usuario", b =>
                {
                    b.Navigation("UsuarioVacinas");
                });

            modelBuilder.Entity("HealthPass.API.Entidades.UsuarioVacina", b =>
                {
                    b.Navigation("UsuarioDosesVacina");
                });

            modelBuilder.Entity("HealthPass.API.Entidades.Vacina", b =>
                {
                    b.Navigation("UsuarioVacinas");
                });
#pragma warning restore 612, 618
        }
    }
}
