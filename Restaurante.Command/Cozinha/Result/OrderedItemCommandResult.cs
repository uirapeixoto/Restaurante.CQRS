using Restaurante.Contract;

namespace Restaurante.Command.Cozinha.Result
{
    public class OrderedItemCommandResult : ICommand
    {
        public int MenuNumber;
        public string Description;
        public bool IsDrink;
        public decimal Price;
    }
}
