using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVM.CabanasDream.Locacao.Domain.Entities;

namespace MVM.CabanasDream.Locacao.Data.Mapping;

public class ArtigoFestaMap : IEntityTypeConfiguration<ArtigoFesta>
{
    public void Configure(EntityTypeBuilder<ArtigoFesta> builder)
    {
        builder.ToTable("cbn_artigos_festa");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnType("uuid")
            .HasColumnName("id");

        builder.Property(x => x.DataCriacao)
            .HasColumnType("timestamp")
            .HasColumnName("data_criacao");

        builder.Property(x => x.Nome)
            .HasColumnType("varchar(100)")
            .HasColumnName("nome");

        builder.Property(x => x.Valor)
            .HasColumnType("decimal(7,2)")
            .HasColumnName("valor");

        builder.Property(x => x.Quantidade)
            .HasColumnType("int")
            .HasColumnName("quantidade");

        builder.Property(x => x.FestaId)
            .HasColumnType("uuid")
            .HasColumnName("festa_id");

        builder.Property(x => x.TemaId)
            .HasColumnType("uuid")
            .HasColumnName("tema_id");

        builder.HasOne(x => x.Tema)
            .WithMany(x => x.ArtigosFestas)
            .HasForeignKey(x => x.TemaId);

        builder.HasOne(x => x.Festa)
            .WithMany(x => x.ArtigosDeFesta)
            .HasForeignKey(x => x.FestaId);
    }
}

