using Azure.Core;
using FantasyGame.Entities;
using FantasyGame.Exceptions;
using FantasyGame.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FantasyGame.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TimeController : Controller
    {
        private readonly ITimeService _timeService;
 
        public TimeController(ITimeService timeService)
        {
            _timeService = timeService;
        }

        [HttpPost]
        public async Task<ActionResult> CadastraTimeFutebol(string nomeTime)
        {
            try
            {
                var time = await _timeService.CadastraTime(nomeTime);

                return Ok("time cadastrado com sucesso.");
            }
            catch(ErroTamanhoCaractere ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ErroAoSalvar ex)
            {
                return BadRequest(ex.Message);
            }
            catch(NaoPermitidoduplicidade ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IResult> ListarTodosTimes(int pagina = 0, int tamanho = 10)
        {
           return await _timeService.BuscarTimes(pagina, tamanho);
        }

        [HttpGet("{id}")]
        public async Task<IResult> ListarTimeId(int id)
        {
            return await _timeService.BuscaTimeId(id);
        }

        [HttpPut]
        public async Task<IResult> EditarCadastroTimeFutebol(TimeFutebol time)
        {
            return await _timeService.EditarCadastroTime(time);
        }

        [HttpDelete("{id}")]
        public async Task<IResult> ApagarCadastroTimeFutebel(int id)
        {
           return await _timeService.ApagarCadastroTime(id);
        }
    }
}
