using Restaurante.Contract;

namespace Restaurante.Query.Query
{
    public class TarefaQuery : IQuery
    {
        private int NumTable { get; }

        public TarefaQuery(int numTable)
        {
            NumTable = numTable;
        }
    }
}
