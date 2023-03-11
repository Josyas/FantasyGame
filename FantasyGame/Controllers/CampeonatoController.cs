using FantasyGame.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FantasyGame.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CampeonatoController : Controller
    {
        private readonly ICampeonatoService _campeonatoService;

        public CampeonatoController(ICampeonatoService campeonatoService)
        {
            _campeonatoService = campeonatoService;
        }

        [HttpGet]
        public async Task<IResult> ListarPartidas()
        {
            return await _campeonatoService.BuscarPartidasJogada();
        }
    }
}
