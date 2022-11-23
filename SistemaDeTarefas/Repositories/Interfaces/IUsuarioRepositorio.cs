using SistemaDeTarefas.Models;
using SistemaDeTarefas.ViewModels;

namespace SistemaDeTarefas.Repositories.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<Usuario>> BuscarTodosUsuariosAsync();
        Task<Usuario> BuscarPorIdAsync(int id);
        Task<Usuario> AdicionarAsync(CreateUsuarioViewModel usuario);
        Task<Usuario> AtualizarAsync(CreateUsuarioViewModel usuario, int id);
        Task<bool> DeletarAsync(int id);
    }
}
