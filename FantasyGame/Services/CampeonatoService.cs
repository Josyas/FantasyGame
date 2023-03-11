using AutoMapper;
using FantasyGame.DTO;
using FantasyGame.Entities;
using FantasyGame.Repositories.Interfaces;
using FantasyGame.Services.Interface;

namespace FantasyGame.Services
{
    public class CampeonatoService : ICampeonatoService
    {
        private readonly ICampeonatoRepositorio _campeonatoRepositorio;
        private readonly IMapper? _mapper;

        public CampeonatoService(ICampeonatoRepositorio campeonatoRepositorio, IMapper mapper)
        {
            _campeonatoRepositorio = campeonatoRepositorio;
            _mapper = mapper;
        }

        public async Task CadastraPartida(string partida, string resultado, int id)
        {
            Partida partidaJogo = new()
            {
                Times = partida,
                Resultados = resultado,
                IdTimeFutebol = id
            };

            await _campeonatoRepositorio.IncluirTime(partidaJogo);

            await _campeonatoRepositorio.Salvar();
        }

        public async Task<IResult> BuscarPartidasJogada()
        {
            await PartidaJogoda();

            var partidaJogadas = await _campeonatoRepositorio.SelecionarPartidasJogada();

            var parditaDTO = _mapper.Map<List<PartidaDTO>>(partidaJogadas);

            if (partidaJogadas != null)
                return Results.Ok(parditaDTO);

            return Results.BadRequest("partidas não encontrada.");
        }

        public async Task PartidaJogoda()
        {
            var listaTime = await _campeonatoRepositorio.SelecionarTodosTime();

            string primeiroTime = "";
            string segundoTime = "";

            foreach (var listaPartida in listaTime)
            {
                var id = listaPartida.Id;
                int incrementar = 1;
                string validacaoPartidaJogada = "";
                const int Derrota = 0;
                const int Empate = 1;
                const int Ganhador = 3;
                Random random = new();
                
                for (int i = 0; i < incrementar; i++)
                    primeiroTime = listaPartida.NomeTime;

                foreach (var listaSegundoTime in listaTime)
                {
                    segundoTime = listaSegundoTime.NomeTime;
                    
                    if (!primeiroTime.Equals(segundoTime))
                    {
                        var partidaTime = $"{primeiroTime} x {segundoTime}";
                                               
                        var golsFeitos = new[] { Derrota, Empate, Ganhador };

                        var primeiroPlacar = golsFeitos[random.Next(golsFeitos.Length)];
                        var segundoPlacar = golsFeitos[random.Next(golsFeitos.Length)];

                        var placarJogo = $"{primeiroPlacar} x {segundoPlacar}";

                        validacaoPartidaJogada = await PartidaIguais(primeiroTime, segundoTime);

                        if (validacaoPartidaJogada != "")
                            await CadastraPartida(partidaTime, placarJogo, id);
                    }
                }
            }
        }

        public async Task<string> PartidaIguais(string primeiroTime, string segundoTime)
        {
            var listaTime = await _campeonatoRepositorio.SelecionarTodosGanhador();
                             
            var timeValidacaoDuplicidade = $"{segundoTime} x {primeiroTime}";

            string partidaTime = "";
            string partida = null;

            if (listaTime.Count() < 1)
                return partida;

            foreach (var listaPartida in listaTime)
            {
                if (listaPartida.Times == timeValidacaoDuplicidade)
                    return partidaTime;
            }

            partidaTime = $"{primeiroTime} x {segundoTime}";

            return partidaTime;
        }
    }
}
