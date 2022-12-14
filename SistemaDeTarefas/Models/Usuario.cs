using System.ComponentModel.DataAnnotations;

namespace SistemaDeTarefas.Models
{
    public class Usuario
    {
        public int Id { get; private set; }

        public string? Nome { get; private set; }

        public string? Email { get; private set; }

        public Usuario(string? nome, string? email)
        {
            Nome = nome;
            Email = email;
        }

        public void SetNome(string nome)
        {
            Nome = nome;
        }
        public void SetEmail(string email)
        {
            Email = email;
        }
    }
}
