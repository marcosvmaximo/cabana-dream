using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVM.CabanasDream.Locacao.Domain;

namespace MVM.CabanasDream.Locacao.Data.Mapping;

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

        builder.HasOne(x => x.Tema)
            .WithMany(x => x.Festas)
            .HasForeignKey(x => x.TemaId);

        builder.Property(x => x.TemaId)
            .HasColumnType("uuid")
            .HasColumnName("tema_id");

        builder.HasOne(x => x.Cliente)
            .WithMany(x => x.Festas)
            .HasForeignKey(x => x.ClienteId);

        builder.Property(x => x.ClienteId)
            .HasColumnType("uuid")
            .HasColumnName("cliente_id");

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
            .HasColumnName("data_realizacao_festa");

        builder.HasMany(x => x.ArtigosDeFesta)
            .WithOne(x => x.Festa)
            .HasForeignKey(x => x.FestaId);
    }
}

