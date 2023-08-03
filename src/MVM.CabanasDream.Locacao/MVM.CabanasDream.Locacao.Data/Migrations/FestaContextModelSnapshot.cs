﻿// <auto-generated />
using System;
using MVM.CabanasDream.Locacao.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MVM.CabanasDream.Locacao.Data.Migrations
{
    [DbContext(typeof(FestaContext))]
    partial class FestaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MVM.CabanasDream.Locacao.Domain.Entities.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("timestamp")
                        .HasColumnName("data_criacao");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("date")
                        .HasColumnName("data_nascimento");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("cbn_clientes", (string)null);
                });

            modelBuilder.Entity("MVM.CabanasDream.Locacao.Domain.Entities.ContratoLocacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uuid")
                        .HasColumnName("cliente_id");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("timestamp")
                        .HasColumnName("data_criacao");

                    b.Property<DateTime>("DataDevolucao")
                        .HasColumnType("date")
                        .HasColumnName("data_devolucao");

                    b.Property<Guid>("FestaId")
                        .HasColumnType("uuid")
                        .HasColumnName("festa_id");

                    b.Property<decimal>("Multa")
                        .HasColumnType("numeric(10,2)")
                        .HasColumnName("valor_multa_contrato");

                    b.Property<decimal>("Valor")
                        .HasColumnType("numeric(10,2)")
                        .HasColumnName("valor_contrato");

                    b.Property<bool>("Vigente")
                        .HasColumnType("bool")
                        .HasColumnName("vigencia");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("cbn_contratos_locacoes", (string)null);
                });

            modelBuilder.Entity("MVM.CabanasDream.Locacao.Domain.Entities.Tema", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("timestamp")
                        .HasColumnName("data_criacao");

                    b.Property<bool>("Disponivel")
                        .HasColumnType("bool")
                        .HasColumnName("disponibilidade");

                    b.Property<int>("Estoque")
                        .HasColumnType("int")
                        .HasColumnName("quantidade_estoque");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("cbn_temas", (string)null);
                });

            modelBuilder.Entity("MVM.CabanasDream.Locacao.Domain.Festa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uuid")
                        .HasColumnName("cliente_id");

                    b.Property<Guid>("ContratoId")
                        .HasColumnType("uuid")
                        .HasColumnName("contrato_locacao_id");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("timestamp")
                        .HasColumnName("data_criacao");

                    b.Property<DateTime>("DataRealizacao")
                        .HasColumnType("date")
                        .HasColumnName("data_realizacao_festa");

                    b.Property<int>("QuantidadeParticipantes")
                        .HasColumnType("int")
                        .HasColumnName("quantidade_participantes");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("status_festa");

                    b.Property<Guid>("TemaId")
                        .HasColumnType("uuid")
                        .HasColumnName("tema_id");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ContratoId")
                        .IsUnique();

                    b.HasIndex("TemaId");

                    b.ToTable("cbn_festas", (string)null);
                });

            modelBuilder.Entity("MVM.CabanasDream.Locacao.Domain.ValueObjects.ItemDeFesta", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("timestamp")
                        .HasColumnName("data_criacao");

                    b.Property<Guid>("FestaId")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("nome");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int")
                        .HasColumnName("quantidade");

                    b.Property<Guid?>("TemaId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("FestaId");

                    b.HasIndex("TemaId");

                    b.ToTable("cbn_items_festa", (string)null);
                });

            modelBuilder.Entity("MVM.CabanasDream.Locacao.Domain.Entities.Cliente", b =>
                {
                    b.OwnsOne("MVM.CabanasDream.Core.Domain.ValueObjects.Contato", "Contato", b1 =>
                        {
                            b1.Property<Guid>("ClienteId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Ddd")
                                .IsRequired()
                                .HasColumnType("varchar(2)")
                                .HasColumnName("ddd_telefone");

                            b1.Property<string>("Email")
                                .IsRequired()
                                .HasColumnType("varchar(255)")
                                .HasColumnName("email");

                            b1.Property<string>("Telefone")
                                .IsRequired()
                                .HasColumnType("varchar(15)")
                                .HasColumnName("telefone");

                            b1.HasKey("ClienteId");

                            b1.ToTable("cbn_clientes");

                            b1.WithOwner()
                                .HasForeignKey("ClienteId");
                        });

                    b.OwnsOne("MVM.CabanasDream.Core.Domain.ValueObjects.Documento", "Documento", b1 =>
                        {
                            b1.Property<Guid>("ClienteId")
                                .HasColumnType("uuid");

                            b1.Property<DateTime>("DataEmissao")
                                .HasColumnType("date")
                                .HasColumnName("data_emissao");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasColumnType("varchar(15)")
                                .HasColumnName("num_documento");

                            b1.Property<int>("Tipo")
                                .HasColumnType("int")
                                .HasColumnName("tipo_documento");

                            b1.HasKey("ClienteId");

                            b1.ToTable("cbn_clientes");

                            b1.WithOwner()
                                .HasForeignKey("ClienteId");
                        });

                    b.OwnsOne("MVM.CabanasDream.Core.Domain.ValueObjects.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<Guid>("ClienteId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Bairro")
                                .IsRequired()
                                .HasColumnType("varchar(255)")
                                .HasColumnName("bairro");

                            b1.Property<string>("Cep")
                                .IsRequired()
                                .HasColumnType("varchar(8)")
                                .HasColumnName("cep");

                            b1.Property<string>("Cidade")
                                .IsRequired()
                                .HasColumnType("varchar(255)")
                                .HasColumnName("endereco_cidade");

                            b1.Property<string>("Logradouro")
                                .IsRequired()
                                .HasColumnType("varchar(255)")
                                .HasColumnName("logradouro");

                            b1.Property<int>("Numero")
                                .HasColumnType("int")
                                .HasColumnName("endereco_numero");

                            b1.Property<string>("UnidadeFederativa")
                                .IsRequired()
                                .HasColumnType("varchar(2)")
                                .HasColumnName("endereco_uf");

                            b1.HasKey("ClienteId");

                            b1.ToTable("cbn_clientes");

                            b1.WithOwner()
                                .HasForeignKey("ClienteId");
                        });

                    b.Navigation("Contato")
                        .IsRequired();

                    b.Navigation("Documento")
                        .IsRequired();

                    b.Navigation("Endereco")
                        .IsRequired();
                });

            modelBuilder.Entity("MVM.CabanasDream.Locacao.Domain.Entities.ContratoLocacao", b =>
                {
                    b.HasOne("MVM.CabanasDream.Locacao.Domain.Entities.Cliente", "Cliente")
                        .WithMany("Contratos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("MVM.CabanasDream.Locacao.Domain.Festa", b =>
                {
                    b.HasOne("MVM.CabanasDream.Locacao.Domain.Entities.Cliente", "Cliente")
                        .WithMany("FestasRealizadas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVM.CabanasDream.Locacao.Domain.Entities.ContratoLocacao", "ContratoLocacao")
                        .WithOne("Festa")
                        .HasForeignKey("MVM.CabanasDream.Locacao.Domain.Festa", "ContratoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVM.CabanasDream.Locacao.Domain.Entities.Tema", "Tema")
                        .WithMany("Festas")
                        .HasForeignKey("TemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("ContratoLocacao");

                    b.Navigation("Tema");
                });

            modelBuilder.Entity("MVM.CabanasDream.Locacao.Domain.ValueObjects.ItemDeFesta", b =>
                {
                    b.HasOne("MVM.CabanasDream.Locacao.Domain.Festa", "Festa")
                        .WithMany("ItensExtras")
                        .HasForeignKey("FestaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVM.CabanasDream.Locacao.Domain.Entities.Tema", null)
                        .WithMany("ItensDeFestas")
                        .HasForeignKey("TemaId");

                    b.Navigation("Festa");
                });

            modelBuilder.Entity("MVM.CabanasDream.Locacao.Domain.Entities.Cliente", b =>
                {
                    b.Navigation("Contratos");

                    b.Navigation("FestasRealizadas");
                });

            modelBuilder.Entity("MVM.CabanasDream.Locacao.Domain.Entities.ContratoLocacao", b =>
                {
                    b.Navigation("Festa")
                        .IsRequired();
                });

            modelBuilder.Entity("MVM.CabanasDream.Locacao.Domain.Entities.Tema", b =>
                {
                    b.Navigation("Festas");

                    b.Navigation("ItensDeFestas");
                });

            modelBuilder.Entity("MVM.CabanasDream.Locacao.Domain.Festa", b =>
                {
                    b.Navigation("ItensExtras");
                });
#pragma warning restore 612, 618
        }
    }
}
