﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoPI.Data;

#nullable disable

namespace ProjetoPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("DoadorId")
                        .HasColumnType("int");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoadorId");

                    b.ToTable("Produtos");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("ProjetoPI.Model.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TipoUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuarios", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Livro", b =>
                {
                    b.HasBaseType("Produto");

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Editora")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.ToTable("Livros", (string)null);
                });

            modelBuilder.Entity("ProjetoPI.Model.Calcado", b =>
                {
                    b.HasBaseType("Produto");

                    b.Property<string>("Tamanho")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.ToTable("Calcados", (string)null);
                });

            modelBuilder.Entity("Roupa", b =>
                {
                    b.HasBaseType("Produto");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Tamanho")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TipoRoupa")
                        .HasColumnType("int");

                    b.ToTable("Roupas", (string)null);
                });

            modelBuilder.Entity("Doador", b =>
                {
                    b.HasBaseType("ProjetoPI.Model.Usuario");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DataNascimentoString")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.ToTable("Doadores", (string)null);
                });

            modelBuilder.Entity("ProjetoPI.Model.Ong", b =>
                {
                    b.HasBaseType("ProjetoPI.Model.Usuario");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("varchar(18)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime(6)");

                    b.ToTable("Ongs", (string)null);
                });

            modelBuilder.Entity("Produto", b =>
                {
                    b.HasOne("Doador", "Doador")
                        .WithMany()
                        .HasForeignKey("DoadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doador");
                });

            modelBuilder.Entity("Livro", b =>
                {
                    b.HasOne("Produto", null)
                        .WithOne()
                        .HasForeignKey("Livro", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjetoPI.Model.Calcado", b =>
                {
                    b.HasOne("Produto", null)
                        .WithOne()
                        .HasForeignKey("ProjetoPI.Model.Calcado", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Roupa", b =>
                {
                    b.HasOne("Produto", null)
                        .WithOne()
                        .HasForeignKey("Roupa", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Doador", b =>
                {
                    b.HasOne("ProjetoPI.Model.Usuario", null)
                        .WithOne()
                        .HasForeignKey("Doador", "IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjetoPI.Model.Ong", b =>
                {
                    b.HasOne("ProjetoPI.Model.Usuario", null)
                        .WithOne()
                        .HasForeignKey("ProjetoPI.Model.Ong", "IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
