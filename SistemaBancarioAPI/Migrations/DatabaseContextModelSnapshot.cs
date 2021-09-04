﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SistemaBancarioAPI.Repositories;

namespace SistemaBancarioAPI.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("SistemaBancarioAPI.Entities.Conta", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Agencia")
                        .HasColumnType("text");

                    b.Property<string>("Conta")
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("(now())");

                    b.Property<decimal>("Saldo")
                        .HasColumnType("numeric");

                    b.Property<string>("TipoNomeConta")
                        .HasColumnType("text");

                    b.Property<Guid>("TitularId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TitularId");

                    b.ToTable("Contas");
                });

            modelBuilder.Entity("SistemaBancarioAPI.Entities.Endereco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Bairro")
                        .HasColumnType("text");

                    b.Property<string>("Cep")
                        .HasColumnType("text");

                    b.Property<string>("Cidade")
                        .HasColumnType("text");

                    b.Property<string>("Complemento")
                        .HasColumnType("text");

                    b.Property<string>("Estado")
                        .HasColumnType("text");

                    b.Property<string>("Logradouro")
                        .HasColumnType("text");

                    b.Property<string>("Numero")
                        .HasColumnType("text");

                    b.Property<Guid>("TitularId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TitularId")
                        .IsUnique();

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("SistemaBancarioAPI.Entities.Titular", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Cpf_Cnpj")
                        .HasColumnType("text");

                    b.Property<DateTime>("DtNascimento")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Titulares");
                });

            modelBuilder.Entity("SistemaBancarioAPI.Entities.Conta", b =>
                {
                    b.HasOne("SistemaBancarioAPI.Entities.Titular", "Titular")
                        .WithMany("Contas")
                        .HasForeignKey("TitularId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SistemaBancarioAPI.Entities.Endereco", b =>
                {
                    b.HasOne("SistemaBancarioAPI.Entities.Titular", "Titular")
                        .WithOne("Endereco")
                        .HasForeignKey("SistemaBancarioAPI.Entities.Endereco", "TitularId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
