using System.ComponentModel;

namespace SistemaDeTarefas.Enums
{
    public enum StatusTarefa
    {
        [Description("A fazer")]
        AFazer = 0,
        [Description("Em andamento")]
        EmAndamento = 1,
        [Description("Concluido")]
        Concluido = 2
    };
}
