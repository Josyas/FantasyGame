using FantasyGame.Entities;

namespace FantasyGame.Services.Interface
{
    public interface ITimeService
    {
        Task<string> CadastraTime(string nome);
        Task<IResult> EditarCadastroTime(TimeFutebol time);
        Task<IResult> BuscaTimeId(int id);
        Task<IResult> ApagarCadastroTime(int id);
        Task<string> NomeTimeDuplicado(string nomeTimeLista);
        Task<IResult> BuscarTimes(int skip, int take);
    }
}
