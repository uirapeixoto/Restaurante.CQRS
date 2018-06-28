using Restaurante.Contract;
using Restaurante.Events;
using Restaurante.Events.Mesas;

namespace Restaurante.Query.Result
{
    public class ChefTodoListQueryResult : ISubscribeTo<FoodOrdered>,
    ISubscribeTo<FoodPrepared>
    {
        public void Handle(FoodOrdered e)
        {
            throw new System.NotImplementedException();
        }

        void ISubscribeTo<FoodPrepared>.Handle(FoodPrepared e)
        {
            throw new System.NotImplementedException();
        }
    }
}
