using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositories.Interfaces;
using SistemaDeTarefas.ViewModels;

namespace SistemaDeTarefas.Repositories
{
    public class TarefaRepositorio : IRepositorioBase<Tarefa, CreateTarefaViewModel>
    {
        private readonly AppDbContext _context;

        public TarefaRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Tarefa>> BuscarTodosAsync()
        {
            var tarefas = await _context
                .Tarefas
                .AsNoTracking()
                .ToListAsync();

            if (tarefas == null)
                throw new Exception("Não há tarefas cadastradas");

            return tarefas;
        }

        public async Task<Tarefa> BuscarPorIdAsync(int id)
        {
            var tarefaId = await _context
                .Tarefas
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (tarefaId == null)
                throw new Exception("Tarefa não encontrada");

            return tarefaId;
        }

        public async Task<Tarefa> AdicionarAsync(CreateTarefaViewModel model)
        {
            Tarefa tarefa = new Tarefa();

            if (model.Nome == null || model.Descricao == null)
                throw new Exception("Nome ou Descricao inválido");

            tarefa.SetNome(model.Nome);
            tarefa.SetDescricao(model.Descricao);

            await _context.Tarefas.AddAsync(tarefa);
            await _context.SaveChangesAsync();

            return tarefa;
        }

        public async Task<Tarefa> AtualizarAsync(CreateTarefaViewModel model, int id)
        {
            Tarefa tarefa = await BuscarPorIdAsync(id);

            tarefa.Status = model.Status;

            _context.Tarefas.Update(tarefa);
            await _context.SaveChangesAsync();

            return tarefa;
        }

        public async Task<bool> DeletarAsync(int id)
        {
            Tarefa tarefa = await BuscarPorIdAsync(id);

            if (tarefa == null)
                throw new Exception("Tarefa não encontrada");

            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
