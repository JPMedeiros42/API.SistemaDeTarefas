using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositories.Interfaces;
using SistemaDeTarefas.ViewModels;

namespace SistemaDeTarefas.Repositories
{
    public class UsuarioRepositorio : IRepositorioBase<Usuario>
    {
        private readonly AppDbContext _context;

        public UsuarioRepositorio(AppDbContext context)
        {
            _context = context;
        }

       public async Task<Usuario> BuscarPorIdAsync(int id)
        {
            var userId = await _context
                .Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (userId == null)
                throw new Exception("Usuário não encontrado");

            return userId;
        }

        public async Task<List<Usuario>> BuscarTodosAsync()
        {
            var usuarios = await _context
                .Usuarios
                .AsNoTracking()
                .ToListAsync();

            if (usuarios == null) 
                throw new Exception("Não há usuários cadastrados");

            return usuarios;
        }

        public async Task<Usuario> AdicionarAsync(Usuario model)
        {

            if (model.Nome == null || model.Email == null)
                throw new Exception("Nome ou Email inválido");

            Usuario usuario = new Usuario(model.Nome, model.Email);

            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        public async Task<Usuario> AtualizarAsync(Usuario model, int id)
        {

            if (model.Nome == null || model.Email == null)
                throw new Exception("Nome ou Email inválido");

            Usuario userId = await BuscarPorIdAsync(id);

            userId.SetNome(model.Nome);
            userId.SetEmail(model.Email);

            _context.Usuarios.Update(userId);
            await _context.SaveChangesAsync();

            return userId;
        }
                
        public async Task<bool> DeletarAsync(int id)
        {
            Usuario userId = await BuscarPorIdAsync(id);

            if (userId == null)
                throw new Exception("Usuário não encontrado");

            _context.Usuarios.Remove(userId); 
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
