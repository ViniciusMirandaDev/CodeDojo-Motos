using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotoDojo.Entities;

namespace MotoDojo.Context
{
    public class MotoEntityTypeConfiguration : IEntityTypeConfiguration<Moto>
    {
        public void Configure(EntityTypeBuilder<Moto> builder)
        {
            builder.ToTable("moto", CoreContext.DEFAULT_SCHEMA);

            builder.HasKey(moto => moto.Id);

            builder.Property(moto => moto.Modelo).IsRequired();
            builder.Property(moto => moto.Preco).IsRequired();
            builder.Property(moto => moto.Tipo).IsRequired();
            builder.Property(moto => moto.DataFabricacao).IsRequired();
            builder.Property(moto => moto.Marca).IsRequired();
            builder.Property(moto => moto.Placa).IsRequired();
        }

    }
}