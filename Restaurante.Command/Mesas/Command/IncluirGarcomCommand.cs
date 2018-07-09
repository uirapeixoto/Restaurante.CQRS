using Restaurante.Contract;

namespace Restaurante.Command.Mesas.Command
{
    public class IncluirGarcomCommand : ICommand
    {
        public string Nome { get; }

        public IncluirGarcomCommand(string nome)
        {
            Nome = nome;
        }
    }
}
