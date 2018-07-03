using Restaurante.Contract;

namespace Restaurante.Query.Result
{
    public sealed class PedidoItemQueryResult : IQueryResult
    {
        private int Id {get;}
        private MenuItemQueryResult MenuItem { get; }

        public PedidoItemQueryResult(int id, MenuItemQueryResult menuItem)
        {
            Id = id;
            MenuItem = menuItem;
        }

    }
}