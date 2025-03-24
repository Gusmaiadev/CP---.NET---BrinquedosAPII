﻿// <auto-generated />
using BrinquedosAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace BrinquedosAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BrinquedosAPI.Data.Brinquedo", b =>
                {
                    b.Property<int>("Id_brinquedo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_brinquedo"));

                    b.Property<string>("Classificacao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)");

                    b.Property<int?>("Id_categoria")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int?>("Id_estoque")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Nome_brinquedo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("Tamanho")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("NVARCHAR2(20)");

                    b.Property<string>("Tipo_brinquedo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)");

                    b.HasKey("Id_brinquedo");

                    b.HasIndex("Id_categoria");

                    b.ToTable("Brinquedos");
                });

            modelBuilder.Entity("BrinquedosAPI.Data.BrinquedoFornecedor", b =>
                {
                    b.Property<int>("BrinquedoId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("FornecedorId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("Id")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("BrinquedoId", "FornecedorId");

                    b.HasIndex("FornecedorId");

                    b.ToTable("BrinquedoFornecedores");
                });

            modelBuilder.Entity("BrinquedosAPI.Data.Categoria", b =>
                {
                    b.Property<int>("Id_categoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_categoria"));

                    b.Property<string>("Nome_categoria")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.HasKey("Id_categoria");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("BrinquedosAPI.Data.Estoque", b =>
                {
                    b.Property<int>("Id_estoque")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_estoque"));

                    b.Property<string>("Faixa")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)");

                    b.Property<int?>("Id_brinquedo")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id_estoque");

                    b.HasIndex("Id_brinquedo")
                        .IsUnique()
                        .HasFilter("\"Id_brinquedo\" IS NOT NULL");

                    b.ToTable("Estoques");
                });

            modelBuilder.Entity("BrinquedosAPI.Data.Fornecedor", b =>
                {
                    b.Property<int>("Id_fornecedor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_fornecedor"));

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("NVARCHAR2(18)");

                    b.Property<string>("Nome_fornecedor")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.Property<string>("Nome_representante")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("NVARCHAR2(15)");

                    b.HasKey("Id_fornecedor");

                    b.HasIndex("CNPJ")
                        .IsUnique();

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("BrinquedosAPI.Data.Brinquedo", b =>
                {
                    b.HasOne("BrinquedosAPI.Data.Categoria", "Categoria")
                        .WithMany("Brinquedos")
                        .HasForeignKey("Id_categoria")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("BrinquedosAPI.Data.BrinquedoFornecedor", b =>
                {
                    b.HasOne("BrinquedosAPI.Data.Brinquedo", "Brinquedo")
                        .WithMany("BrinquedoFornecedores")
                        .HasForeignKey("BrinquedoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BrinquedosAPI.Data.Fornecedor", "Fornecedor")
                        .WithMany("BrinquedoFornecedores")
                        .HasForeignKey("FornecedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brinquedo");

                    b.Navigation("Fornecedor");
                });

            modelBuilder.Entity("BrinquedosAPI.Data.Estoque", b =>
                {
                    b.HasOne("BrinquedosAPI.Data.Brinquedo", "Brinquedo")
                        .WithOne("Estoque")
                        .HasForeignKey("BrinquedosAPI.Data.Estoque", "Id_brinquedo")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Brinquedo");
                });

            modelBuilder.Entity("BrinquedosAPI.Data.Brinquedo", b =>
                {
                    b.Navigation("BrinquedoFornecedores");

                    b.Navigation("Estoque");
                });

            modelBuilder.Entity("BrinquedosAPI.Data.Categoria", b =>
                {
                    b.Navigation("Brinquedos");
                });

            modelBuilder.Entity("BrinquedosAPI.Data.Fornecedor", b =>
                {
                    b.Navigation("BrinquedoFornecedores");
                });
#pragma warning restore 612, 618
        }
    }
}
