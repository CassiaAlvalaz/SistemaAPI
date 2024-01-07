using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeMusica.Models;
using SistemaDeMusica.Repositorios.Interfaces;

namespace SistemaDeMusica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaMusicaController : ControllerBase
    {
        private readonly ITarefaMusicaRepositorio _musicaRepositorio;

        public TarefaMusicaController(ITarefaMusicaRepositorio musicaRepositorio)
        {
            _musicaRepositorio =  musicaRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<TarefaMusica>>> ListarTodasMusicas()
        {
            List<TarefaMusica> musicas = await _musicaRepositorio.BuscarTodasMusicas();
            return Ok(musicas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TarefaMusica>> BuscarPorId(int id)
        {
            TarefaMusica musicas = await _musicaRepositorio.BuscarPorId(id);
            return Ok(musicas);
        }

        [HttpPost]
        public async Task<ActionResult<TarefaMusica>> Cadastrar([FromBody] TarefaMusica tarefaMusica)
        {
            TarefaMusica musicas = await _musicaRepositorio.Adicionar(tarefaMusica);
            return Ok(musicas);
        }

        [HttpPut("id")]
        public async Task<ActionResult<TarefaMusica>> Atualizar([FromBody] TarefaMusica tarefaMusica, int id)
        {
            tarefaMusica.Id = id;
            TarefaMusica musicas = await _musicaRepositorio.Atualizar(tarefaMusica, id);
            return Ok(musicas);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<TarefaMusica>> Apagar(int id)
        {
            bool apagado = await _musicaRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
