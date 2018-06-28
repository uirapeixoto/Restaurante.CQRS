using System.Collections.Generic;

namespace Restaurante.Query.Result
{
    public class FoodOrderedQueryResult
    {
        public int Id;
        public List<OrderedItemQueryResult> Items;
    }
}
