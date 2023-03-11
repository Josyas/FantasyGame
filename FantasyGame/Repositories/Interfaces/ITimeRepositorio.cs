using FantasyGame.Entities;

namespace FantasyGame.Repositories.Interfaces
{
    public interface ITimeRepositorio
    {
        Task IncluirTime(TimeFutebol time);
        void EditarTime(TimeFutebol time);
        Task<TimeFutebol> SelecionarTimeId(int id);
        Task<IEnumerable<TimeFutebol>> SelecionarTodosTime(int skip, int take);
        Task<bool> Salvar();
        void ExlcuirTime(TimeFutebol time);
        Task<IList<TimeFutebol>> ListaTime();
    }
}
