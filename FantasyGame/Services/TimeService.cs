using AutoMapper;
using FantasyGame.DTO;
using FantasyGame.Entities;
using FantasyGame.Exceptions;
using FantasyGame.Repositories.Interfaces;
using FantasyGame.Services.Interface;

namespace FantasyGame.Services
{
    public class TimeService : ITimeService
    {
        private readonly ITimeRepositorio _timeRepositorio;
        private readonly IMapper? _mapper;

        public TimeService(ITimeRepositorio timeRepositorio, IMapper mapper)
        {
            _timeRepositorio = timeRepositorio;
            _mapper = mapper;
        }

        public async Task<string> CadastraTime(string nome)
        {
            if (nome.Length < 3)
                throw new ErroTamanhoCaractere("digite no mínimo três letras.");
       
            await NomeTimeDuplicado(nome);

            TimeFutebol time = new()
            {
                NomeTime = nome
            };

            if (time == null)
                throw new ErroAoSalvar("erro ao salvar time.");
                    
            await _timeRepositorio.IncluirTime(time);

            await _timeRepositorio.Salvar();

            return nome;
        }

        public async Task<IResult> EditarCadastroTime(TimeFutebol time)
        {
            _timeRepositorio.EditarTime(time);

            if (await _timeRepositorio.Salvar())
                return Results.Ok("cadastro do time alterado com sucesso.");

           return Results.BadRequest("erro ao alterar cadastro do time.");
        }

        public async Task<IResult> BuscaTimeId(int id)
        {
            var buscarTimeId = await _timeRepositorio.SelecionarTimeId(id);
            
            var buscarTimeDTO = _mapper.Map<IdTimeFutebolDTO>(buscarTimeId);

            if (buscarTimeDTO != null)
                return Results.Ok(buscarTimeDTO);

            return Results.BadRequest("time não encontrado.");
        }

        public async Task<IResult> ApagarCadastroTime(int id)
        {
           var excluirCadastroTime = await _timeRepositorio.SelecionarTimeId(id);

            if (excluirCadastroTime == null)
                return Results.NotFound("cadastro do time não encontrado.");

             _timeRepositorio.ExlcuirTime(excluirCadastroTime);

            if (await _timeRepositorio.Salvar())
                return Results.Ok("cadastro apagado com sucesso.");

            return Results.BadRequest("ocorreu um erro ao apagar cadastro do time.");
        }

        public async Task<IResult> BuscarTimes(int skip, int take)
        {
            var listaTime = await _timeRepositorio.SelecionarTodosTime(skip, take);

            var timeFutebolDTO = _mapper.Map<List<TimeFutebolDTO>>(listaTime);

            if (timeFutebolDTO != null)
                return Results.Ok(timeFutebolDTO);


            return Results.BadRequest("times não encontrado.");
        }

        public async Task<string> NomeTimeDuplicado(string nomeTimeLista)
        {
            var listaTime = await _timeRepositorio.ListaTime();

            foreach (var lista in listaTime)
            {
                if (lista.NomeTime == nomeTimeLista)
                   throw new NaoPermitidoduplicidade("o nome já está em uso.");
            }

            return nomeTimeLista;
        }
    }
}
