using SistemaDeTarefas.Enums;

namespace SistemaDeTarefas.ViewModels
{
    public class CreateTarefaViewModel
    {
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public StatusTarefa Status { get; set;}
    }
}
