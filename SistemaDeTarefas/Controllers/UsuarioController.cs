using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositories.Interfaces;
using SistemaDeTarefas.ViewModels;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IRepositorioBase<Usuario> _repositorioBase;

        public UsuarioController(IRepositorioBase<Usuario> repositorioBase)
        {
            _repositorioBase = repositorioBase;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> GetAsync()
        {
            List<Usuario> usuarios = await _repositorioBase.BuscarTodosAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetByIdAsync(int id)
        {
            try
            {
                Usuario usuario = await _repositorioBase.BuscarPorIdAsync(id);
                return Ok(usuario);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> PostAsync(
            [FromBody] CreateUsuarioViewModel model)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            Usuario user = new Usuario(model.Nome,model.Email);

            try
            {
                Usuario usuario = await _repositorioBase.AdicionarAsync(user);
                return Ok(usuario);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        [HttpPut]
        public async Task<ActionResult<Usuario>> UpdateAsync(
            [FromBody] CreateUsuarioViewModel model, int id)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            Usuario user = new Usuario(model.Nome, model.Email);

            try
            {
                Usuario usuario = await _repositorioBase.AtualizarAsync( user, id );
                return Ok(usuario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpDelete]
        public async Task<ActionResult<Usuario>> DeletarAsync(int id)
        {
            try
            {
                await _repositorioBase.DeletarAsync(id);
                return Ok($"Usuário {id} Apagado");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
