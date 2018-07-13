using Restaurante.Contract;

namespace Restaurante.Query.Result
{
    public sealed class PedidoItemQueryResult : IQueryResult
    {
        public int Id {get;}
        public string Descricao { get; }
        public decimal AjustePreco { get; }
        public MenuItemQueryResult MenuItem { get; }

        public PedidoItemQueryResult(int id, MenuItemQueryResult menuItem, decimal ajustePreco = (decimal) 0.0, string descricao = "" )
        {
            Id = id;
            MenuItem = menuItem;
            AjustePreco = ajustePreco;
            Descricao = descricao;
        }

    }
}