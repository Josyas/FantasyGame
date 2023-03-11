using FantasyGame.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FantasyGame.Mappings
{
    public class PartidaMap : IEntityTypeConfiguration<Partida>
    {
        public void Configure(EntityTypeBuilder<Partida> builder)
        {
            builder.ToTable("Partida");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Times)
                .HasColumnType("VARCHAR")
                .HasMaxLength(250);

            builder.Property(x => x.Resultados)
             .HasColumnType("VARCHAR")
             .HasMaxLength(250);

            builder.HasOne(x => x.TimeFutebol)
                   .WithMany(x => x.Partida)
                   .HasConstraintName("FK_TimeFutebol_Partida")
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
