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

    }
}
