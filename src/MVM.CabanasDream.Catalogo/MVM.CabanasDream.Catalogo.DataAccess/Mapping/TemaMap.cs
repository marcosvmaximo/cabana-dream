using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVM.CabanasDream.BussinesLogic.Models;

namespace MVM.CabanasDream.DataAccess.Mapping;

public class TemaMap : IEntityTypeConfiguration<Tema>
{
    public void Configure(EntityTypeBuilder<Tema> builder)
    {
        builder.ToTable("cbn_esttemas");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnType("UUID")
            .HasColumnName("id");

        builder.Property(x => x.DataCriacao)
            .HasColumnType("datetime")
            .HasColumnName("data_criacao");

        builder.Property(x => x.Disponivel)
            .HasColumnType("bool")
            .HasColumnName("disponibilidade");

        builder.Property(x => x.Nome)
            .HasColumnType("varchar(255)")
            .HasColumnName("nome");

        builder.Property(x => x.Imagem)
            .HasColumnType("varchar(2500)")
            .HasColumnName("url_imagem");

        builder.HasMany(x => x.Itens)
            .WithOne(x => x.Tema)
            .HasForeignKey(x => x.TemaId);
    }
}

