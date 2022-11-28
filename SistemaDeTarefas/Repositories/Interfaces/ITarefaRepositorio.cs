using SistemaDeTarefas.Models;
using SistemaDeTarefas.ViewModels;

namespace SistemaDeTarefas.Repositories.Interfaces
{
    public interface ITarefaRepositorio
    {
        Task<List<Tarefa>> BuscarTarefasAsync();
        Task<Tarefa> BuscarTarefaIdAsync(int id);
        Task<Tarefa> AdicionarAsync(CreateTarefaViewModel model);
        Task<Tarefa> AtualizarAsync(CreateTarefaViewModel model, int id);
        Task<bool> DeleteAsync(int id);
    }
}
