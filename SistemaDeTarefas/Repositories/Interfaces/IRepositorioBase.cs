namespace SistemaDeTarefas.Repositories.Interfaces
{
    public interface IRepositorioBase<T>
    {
        Task<List<T>> BuscarTodosAsync();
        Task<T> BuscarPorIdAsync(int id);
        Task<T> AdicionarAsync(T model);
        Task<T> AtualizarAsync(T model, int id);
        Task<bool> DeletarAsync(int id);
    }
}
