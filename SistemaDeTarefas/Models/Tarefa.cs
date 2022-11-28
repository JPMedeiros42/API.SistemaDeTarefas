using SistemaDeTarefas.Enums;

namespace SistemaDeTarefas.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string? Nome { get; private set; }
        public string? Descricao { get; private set; }
        public StatusTarefa Status { get; set; }

        public void SetNome(string nome)
        {
            Nome = nome;
        }
        public void SetDescricao(string descricao)
        {
            Descricao= descricao;
        }

        public Tarefa(string? nome, string? descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }

        public Tarefa(StatusTarefa status)
        {
            Status = status;
        }
    }
}
