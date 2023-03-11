using FantasyGame.Data;
using FantasyGame.Entities;
using FantasyGame.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FantasyGame.Repositories
{
    public class TimeRepositorio : ITimeRepositorio
    {
        private readonly AppDbContext _appDbContext;

        public TimeRepositorio(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void EditarTime(TimeFutebol time)
        {
            _appDbContext.Entry(time).State = EntityState.Modified;
        }

        public void ExlcuirTime(TimeFutebol time)
        {
           _appDbContext.Times.Remove(time);
        }

        public async Task IncluirTime(TimeFutebol time)
        {
           await _appDbContext.Times.AddAsync(time);
        }

        public async Task<IList<TimeFutebol>> ListaTime()
        {
            return await _appDbContext.Times.AsNoTracking().ToListAsync();
        }

        public async Task<bool> Salvar()
        {
           return await _appDbContext.SaveChangesAsync() > 0;
        }

        public async Task<TimeFutebol> SelecionarTimeId(int id)
        {
            return await _appDbContext.Times.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TimeFutebol>> SelecionarTodosTime(int skip, int take)
        {
            return await _appDbContext.Times.AsNoTracking().Skip(skip).Take(take).ToListAsync();
        }
    }
}
