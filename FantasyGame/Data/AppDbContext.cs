using FantasyGame.Entities;
using FantasyGame.Mappings;
using Microsoft.EntityFrameworkCore;

namespace FantasyGame.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<TimeFutebol> Times { get; set; }
        public DbSet<Partida> Partidas { get; set; }
        public DbSet<Classificacao> Classificacaos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
          => options.UseSqlServer(@"");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TimeMap());
            modelBuilder.ApplyConfiguration(new ClassificacaoMap());
            modelBuilder.ApplyConfiguration(new PartidaMap());
        }
    }
}
