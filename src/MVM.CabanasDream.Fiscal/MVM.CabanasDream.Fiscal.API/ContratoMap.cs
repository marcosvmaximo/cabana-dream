using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVM.CabanasDream.Locacao.Domain.Entities;

namespace MVM.CabanasDream.Locacao.Data.Mapping;

public class ContratoMap : IEntityTypeConfiguration<ContratoLocacao>
{
    public void Configure(EntityTypeBuilder<ContratoLocacao> builder)
    {
        builder.ToTable("cbn_contratos_locacoes");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnType("uuid")
            .HasColumnName("id");

        builder.Property(x => x.DataCriacao)
            .HasColumnType("timestamp")
            .HasColumnName("data_criacao");

        builder.HasOne(x => x.Festa)
            .WithOne(x => x.ContratoLocacao)
            .HasForeignKey<ContratoLocacao>(x => x.FestaId);

        builder.Property(x => x.FestaId)
            .HasColumnType("uuid")
            .HasColumnName("festa_id");

        builder.HasOne(x => x.Cliente)
            .WithMany(x => x.Contratos)
            .HasForeignKey(x => x.ClienteId);

        builder.Property(x => x.ClienteId)
            .HasColumnType("uuid")
            .HasColumnName("cliente_id");

        builder.Property(x => x.Multa)
            .HasColumnType("numeric(10,2)")
            .HasColumnName("valor_multa_contrato");

        builder.Property(x => x.Valor)
            .HasColumnType("numeric(10,2)")
            .HasColumnName("valor_contrato");

        builder.Property(x => x.Vigente)
            .HasColumnType("bool")
            .HasColumnName("vigencia");

        builder.Property(x => x.DataDevolucao)
            .HasColumnType("date")
            .HasColumnName("data_devolucao");
    }
}

