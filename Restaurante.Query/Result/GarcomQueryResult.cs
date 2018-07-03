using Restaurante.Contract;

namespace Restaurante.Query.Result
{
    public class GarcomQueryResult : IQueryResult
    {
        public int Id { get; }
        public string Nome { get; }

        public GarcomQueryResult(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
