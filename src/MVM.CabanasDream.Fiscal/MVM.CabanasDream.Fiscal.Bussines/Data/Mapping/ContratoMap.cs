using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVM.CabanasDream.Fiscal.API.Models;

namespace MVM.CabanasDream.Fiscal.Data.Mapping;

public class ContratoMap : IEntityTypeConfiguration<Contrato>
{
    public void Configure(EntityTypeBuilder<Contrato> builder)
    {
        builder.ToTable("cbn_contratos_locacoes");

        builder.HasKey(c => c.Id);

        builder.Property(x => x.DataCriacao)
            .HasColumnType("timestamp")
            .HasColumnName("data_criacao");

        builder.Property(c => c.ClienteId)
            .HasColumnType("uuid")
            .HasColumnName("cliente_id");

        builder.Property(c => c.FestaId)
            .HasColumnType("uuid")
            .HasColumnName("festa_id");

        builder.Property(c => c.DataDevolucao)
            .HasColumnType("datetime")
            .HasColumnName("data_devolucao");

        builder.Property(c => c.Multa)
            .HasColumnType("decimal(9, 2)")
            .HasColumnName("multa");

        builder.Property(c => c.Valor)
            .HasColumnType("decimal(9, 2)")
            .HasColumnName("valor");

        builder.Property(c => c.Vigente)
            .IsRequired()
            .HasColumnType("bool")
            .HasColumnName("vigencia");

        builder.HasOne(c => c.Cliente)
            .WithMany(x => x.Contratos)
            .HasForeignKey(c => c.ClienteId);

        builder.HasOne(c => c.Festa)
            .WithOne(x => x.Contrato)
            .HasForeignKey<Contrato>(c => c.FestaId);
    }
}

