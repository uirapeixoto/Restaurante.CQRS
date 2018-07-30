using Restaurante.Contract;

namespace Restaurante.Query.Result
{
    public sealed class MenuItemQueryResult : IQueryResult
    {
        public int Id { get; }
        public int NumMenuItem { get; }
        public string Descricao { get; }
        public decimal Valor { get; }
        public bool Bebida { get; }
        public bool Ativo { get; }

        public MenuItemQueryResult(int id, int numMenuItem, string descricao, decimal valor, bool bebida, bool ativo)
        {
            Id = id;
            NumMenuItem = numMenuItem;
            Descricao = descricao;
            Valor = valor;
            Bebida = bebida;
            Ativo = ativo;
        }
    }
}