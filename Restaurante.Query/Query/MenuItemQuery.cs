using Restaurante.Contract;

namespace Restaurante.Query.Query
{
    public class MenuItemQuery : IQuery
    {
        private int Id { get; }

        public MenuItemQuery(int id)
        {
            Id = id;
        }
    }
}
