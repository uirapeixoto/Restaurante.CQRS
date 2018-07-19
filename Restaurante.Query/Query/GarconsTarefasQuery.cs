using Restaurante.Contract;

namespace Restaurante.Query.Query
{
    public class GarconsTarefasQuery : IQuery
    {
        public int Id { get; }

        public GarconsTarefasQuery(int id)
        {
            Id = id;
        }
    }
}
