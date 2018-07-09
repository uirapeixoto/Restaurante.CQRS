using Restaurante.Contract;

namespace Restaurante.Query.Query
{
    public class MesaAbertaQuery : IQuery
    {
        public int Id { get; }

        public MesaAbertaQuery(int id)
        {
            Id = id;
        }
    }
}
