namespace SistemaDeTarefas.Repositories.Interfaces
{
    public interface IRepositorioBase<T, E>
    {
        Task<List<T>> BuscarTodosAsync();
        Task<T> BuscarPorIdAsync(int id);
        Task<T> AdicionarAsync(E model);
        Task<T> AtualizarAsync(E model, int id);
        Task<bool> DeletarAsync(int id);
    }
}
