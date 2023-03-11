using FantasyGame.Entities;

namespace FantasyGame.Repositories.Interfaces
{
    public interface ICampeonatoRepositorio
    {
        Task<List<TimeFutebol>> SelecionarTodosTime();
        Task<bool> Salvar();
        Task IncluirTime(Partida partida);
        Task<List<Partida>> SelecionarTodosGanhador();
        Task<IEnumerable<Partida>> SelecionarPartidasJogada();
    }
}
