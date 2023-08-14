using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVM.CabanasDream.Fiscal.API.Models;
using MVM.CabanasDream.Fiscal.API.Models.Entities;

namespace MVM.CabanasDream.Fiscal.API.Data.Mapping;

public class FestaMap : IEntityTypeConfiguration<Festa>
{
    public void Configure(EntityTypeBuilder<Festa> builder)
    {
        builder.ToTable("cbn_festas");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnType("uuid")
            .HasColumnName("id");

        builder.Property(x => x.DataCriacao)
            .HasColumnType("timestamp")
            .HasColumnName("data_criacao");

        builder.Property(x => x.QuantidadeParticipantes)
            .HasColumnType("int")
            .HasColumnName("quantidade_participantes");

        builder.Property(x => x.Status)
            .HasColumnType("int")
            .HasColumnName("status_festa");

        builder.Property(x => x.DataRealizacao)
            .HasColumnType("date")
            .HasColumnName("data_realizacao_festa");

        builder.Property(x => x.ContratoId)
            .HasColumnType("uuid")
            .HasColumnName("contrato_id");

        builder.Property(x => x.QuantidadeArtigosDeFestasExtra)
            .HasColumnType("int")
            .HasColumnName("quantidade_artigos_extras");

        builder.HasOne(x => x.Contrato)
            .WithOne(x => x.Festa)
            .HasForeignKey<Contrato>(x => x.FestaId);
    }
}

