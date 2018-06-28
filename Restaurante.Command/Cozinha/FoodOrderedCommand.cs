using Restaurante.Contract;
using System.Collections.Generic;

namespace Restaurante.Command.Cozinha
{
    public class FoodOrderedCommand : ICommand
    {
        public int PedidoId;
        public List<OrderedItemCommand> Items;
    }
}
