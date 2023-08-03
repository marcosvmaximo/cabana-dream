using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVM.CabanasDream.Locacao.Domain.Entities;

namespace MVM.CabanasDream.Locacao.Data.Mapping;

public class TemaMap : IEntityTypeConfiguration<Tema>
{
    public void Configure(EntityTypeBuilder<Tema> builder)
    {
        builder.ToTable("cbn_temas");

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

        builder.Property(x => x.Disponivel)
            .HasColumnType("bool")
            .HasColumnName("disponibilidade");

        builder.Property(x => x.Estoque)
            .HasColumnType("int")
            .HasColumnName("quantidade_estoque");

        builder.HasMany(x => x.Festas)
            .WithOne(x => x.Tema)
            .HasForeignKey(x => x.TemaId);

        //builder.HasMany(x => x.ItensDeFestas)
    }
}

