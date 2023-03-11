using FantasyGame.Entities;

namespace FantasyGame.Services.Interface
{
    public interface ICampeonatoService
    {
        Task PartidaJogoda();
        Task CadastraPartida(string partida, string resultado, int id);
        Task<string> PartidaIguais(string primeiroTime, string segundoTime);
        Task<IResult> BuscarPartidasJogada();
    }
}
