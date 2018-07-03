using Restaurante.Contract;

namespace Restaurante.Query.Query
{
    public class MesaAbertaQuery : IQuery
    {
        public int Id { get; }
        public int NumMesa { get; }

        public MesaAbertaQuery(int id, int numMesa)
        {
            Id = id;
            NumMesa = numMesa;
        }
    }
}
