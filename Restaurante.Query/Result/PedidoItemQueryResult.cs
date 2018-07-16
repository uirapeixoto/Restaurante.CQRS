using Restaurante.Contract;
using System;

namespace Restaurante.Query.Result
{
    public sealed class PedidoItemQueryResult : IQueryResult
    {
        public int Id {get;}
        public string Descricao { get; }
        public decimal AjustePreco { get; }
        public DateTime? AServir { get; }
        public DateTime? EmPreparacao { get; }
        public DateTime? Servido { get; }
        public MenuItemQueryResult MenuItem { get; }
        public DateTime? AService { get; }
        public DateTime? EmPreaparacao { get; }

        public PedidoItemQueryResult(int id, MenuItemQueryResult menuItem, DateTime? aService, DateTime? emPreaparacao, DateTime? servido, decimal ajustePreco = (decimal) 0.0, string descricao = "" )
        {
            Id = id;
            MenuItem = menuItem;
            AService = aService;
            EmPreaparacao = emPreaparacao;
            Servido = servido;
            AjustePreco = ajustePreco;
            Descricao = descricao;
        }

    }
}