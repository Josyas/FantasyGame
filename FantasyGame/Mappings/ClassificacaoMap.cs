using FantasyGame.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FantasyGame.Mappings
{
    public class ClassificacaoMap : IEntityTypeConfiguration<Classificacao>
    {
        public void Configure(EntityTypeBuilder<Classificacao> builder)
        {
            builder.ToTable("Classificacao");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Campeao)
                .HasColumnType("VARCHAR")
                .HasMaxLength(350);

            builder.Property(x => x.Vice)
                .HasColumnType("VARCHAR")
                .HasMaxLength(350);

            builder.Property(x => x.Terceiro)
                .HasColumnType("VARCHAR")
                .HasMaxLength(350);

            builder.HasOne(x => x.Partidas)
                   .WithMany(x => x.Classificacao)
                   .HasConstraintName("FK_Classificacao_Partidas")
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
