using Restaurante.Contract;
using System;

namespace Restaurante.Query.Result
{
    public class CozinhaTarefasQueryResult : IQueryResult
    {
        public int MesaId { get; }
        public int NumMesa { get; }
        public int PedidoId { get; }
        public string Descricao { get; }
        public int Quantidade { get; }
        public decimal AjustePreco { get; }
        public DateTime? AServir { get; }
        public DateTime? EmPreparacao { get; }
        public DateTime? Servido { get; }
        public MenuItemQueryResult MenuItem { get; }

        public CozinhaTarefasQueryResult(int mesaId, int numMesa, int pedidoId, MenuItemQueryResult menuItem, int quantidade, DateTime? aServir, DateTime? emPreparacao, DateTime? servido, decimal ajustePreco , string descricao)
        {
            MenuItem = menuItem;
            Quantidade = quantidade;
            AServir = aServir;
            EmPreparacao = emPreparacao;
            Servido = servido;
            AjustePreco = ajustePreco;
            Descricao = descricao ;
        }
    }
}
