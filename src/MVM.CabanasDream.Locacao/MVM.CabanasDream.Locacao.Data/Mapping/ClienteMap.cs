using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVM.CabanasDream.Locacao.Domain.Entities;

namespace MVM.CabanasDream.Locacao.Data.Mapping;

public class ClienteMap : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("cbn_clientes");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnType("uuid")
            .HasColumnName("id");

        builder.Property(x => x.DataCriacao)
            .HasColumnType("timestamp")
            .HasColumnName("data_criacao");

        builder.Property(x => x.Nome)
            .HasColumnType("varchar(255)")
            .HasColumnName("nome");

        builder.Property(x => x.DataNascimento)
            .HasColumnType("date")
            .HasColumnName("data_nascimento");

        builder.HasMany(x => x.Contratos)
            .WithOne(x => x.Cliente)
            .HasForeignKey(x => x.ClienteId);

        builder.HasMany(x => x.FestasRealizadas)
            .WithOne(x => x.Cliente)
            .HasForeignKey(x => x.ClienteId);

        builder.OwnsOne(x => x.Contato, c =>
        {
            c.Property(x => x.Ddd)
                .HasColumnType("varchar(2)")
                .HasColumnName("ddd_telefone");

            c.Property(x => x.Telefone)
                .HasColumnType("varchar(15)")
                .HasColumnName("telefone");

            c.Property(x => x.Email)
                .HasColumnType("varchar(255)")
                .HasColumnName("email");
        });

        builder.OwnsOne(x => x.Endereco, e =>
        {
            e.Property(x => x.Cep)
                .HasColumnType("varchar(8)")
                .HasColumnName("cep");

            e.Property(x => x.Logradouro)
                .HasColumnType("varchar(255)")
                .HasColumnName("logradouro");

            e.Property(x => x.Bairro)
                .HasColumnType("varchar(255)")
                .HasColumnName("bairro");

            e.Property(x => x.Cidade)
                .HasColumnType("varchar(255)")
                .HasColumnName("endereco_cidade");

            e.Property(x => x.Numero)
                .HasColumnType("int")
                .HasColumnName("endereco_numero");

            e.Property(x => x.UnidadeFederativa)
                .HasColumnType("varchar(2)")
                .HasColumnName("endereco_uf");
        });

        builder.OwnsOne(x => x.Documento, d =>
        {
            d.Property(x => x.DataEmissao)
                .HasColumnType("date")
                .HasColumnName("data_emissao");

            d.Property(x => x.Numero)
                .HasColumnType("varchar(15)")
                .HasColumnName("num_documento");

            d.Property(x => x.Tipo)
                .HasColumnType("int")
                .HasColumnName("tipo_documento");
        });
    }
}

