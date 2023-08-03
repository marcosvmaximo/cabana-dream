using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVM.CabanasDream.BussinesLogic.Models;
namespace MVM.CabanasDream.DataAccess.Mapping;

public class ItemMap : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.ToTable("cbn_estitems");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnType("UUID")
            .HasColumnName("id");

        builder.Property(x => x.DataCriacao)
            .HasColumnType("datetime")
            .HasColumnName("data_criacao");

        builder.Property(x => x.Tipo)
            .HasColumnType("int")
            .HasColumnName("tipo_objeto");

        builder.Property(x => x.Quantidade)
            .HasColumnType("int")
            .HasColumnName("quantidade_objeto");

        builder.HasOne(x => x.Tema)
            .WithMany(x => x.Itens)
            .HasForeignKey(x => x.TemaId);
    }
}

