using FantasyGame.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FantasyGame.Mappings
{
    public class TimeMap : IEntityTypeConfiguration<TimeFutebol>
    {
        public void Configure(EntityTypeBuilder<TimeFutebol> builder)
        {
            builder.ToTable("Time");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.NomeTime)
                .HasColumnType("VARCHAR")
                .HasMaxLength(250);
        }
    }
}
