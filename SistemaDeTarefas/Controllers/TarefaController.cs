using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositories.Interfaces;
using SistemaDeTarefas.ViewModels;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly IRepositorioBase<Tarefa> _repositorioBase;

        public TarefaController(IRepositorioBase<Tarefa> repositorioBase)
        {
            _repositorioBase = repositorioBase;
        }

        [HttpGet]
        public async Task<ActionResult<List<Tarefa>>> GetAsync()
        {
            List<Tarefa> tarefas = await _repositorioBase.BuscarTodosAsync();
            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tarefa>> GetByIdAsync(int id)
        {
            try
            {
                Tarefa tarefas = await _repositorioBase.BuscarPorIdAsync(id);
                return Ok(tarefas);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Tarefa>> PostAsync(
            [FromBody] CreateTarefaViewModel model)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            Tarefa _tarefa = new Tarefa(model.Nome, model.Descricao);

            try
            {
                Tarefa tarefa = await _repositorioBase.AdicionarAsync(_tarefa);
                return Ok(tarefa);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPut]
        public async Task<ActionResult<Tarefa>> UpdateAsync(
            [FromBody] CreateTarefaViewModel model, int id)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            Tarefa _tarefa = new Tarefa(model.Status);

            try
            {
                Tarefa tarefa = await _repositorioBase.AtualizarAsync(_tarefa, id);
                return Ok(tarefa);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpDelete]
        public async Task<ActionResult<Tarefa>> DeletarAsync(int id)
        {
            try
            {
                await _repositorioBase.DeletarAsync(id);
                return Ok($"Tarefa {id} Apagada");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
