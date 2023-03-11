using FantasyGame.Data;
using FantasyGame.Entities;
using FantasyGame.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FantasyGame.Repositories
{
    public class CampeonatoRepositorio : ICampeonatoRepositorio
    {
        private readonly AppDbContext _appDbContext;

        public CampeonatoRepositorio(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task IncluirTime(Partida partida)
        {
            await _appDbContext.AddAsync(partida);
        }

        public async Task<bool> Salvar()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Partida>> SelecionarPartidasJogada()
        {
           return await _appDbContext.Partidas.AsNoTracking().ToListAsync();
        }

        public async Task<List<Partida>> SelecionarTodosGanhador()
        {
            return await _appDbContext.Partidas.AsNoTracking().ToListAsync();
        }

        public async Task<List<TimeFutebol>> SelecionarTodosTime()
        {
            return await _appDbContext.Times.ToListAsync();
        }
    }
}
