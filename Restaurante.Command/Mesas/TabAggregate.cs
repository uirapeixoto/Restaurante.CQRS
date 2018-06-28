using Restaurante.Contract;
using Restaurante.Dominio.Mesa;
using Restaurante.Dominio.Pedido;
using Restaurante.Dominio.Restaurante;
using Restaurante.Events;
using Restaurante.Events.Mesas;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Restaurante.Command
{
    public class TabAggregate : Aggregate, 
        IHandleCommand<OpenTab>, 
        IHandleCommand<PlaceOrder>,
        IApplyEvent<TabOpened>
    {
        private bool _open = false;
        private List<OrderedItem> outstandingDrinks = new List<OrderedItem>();
        private List<OrderedItem> outstandingFood = new List<OrderedItem>();
        private List<OrderedItem> preparedFood = new List<OrderedItem>();

        private bool open;
        private decimal servedItemsValue;

        public void Apply(TabOpened e)
        {
            _open = true;
        }

        public void Apply(DrinksOrdered e)
        {
            outstandingDrinks.AddRange(e.Items);
        }

        public void Apply(DrinksServed e)
        {
            foreach (var num in e.MenuNumbers)
            {
                var item = outstandingDrinks.First(d => d.MenuNumber == num);
                outstandingDrinks.Remove(item);
                servedItemsValue += item.Price;
            }
        }

        public IEnumerable Handle(OpenTab c)
        {
            yield return new TabOpened
            {
                Id = c.Id,
                TableNumber = c.TableNumber,
                Waiter = c.Waiter
            };
        }

        public IEnumerable Handle(PlaceOrder c)
        {
            if (!_open)
                throw new TabNotOpen();

            var drink = c.Items.Where(i => i.IsDrink).ToList();
            if (drink.Any())
                yield return new DrinksOrdered
                {
                    Id = c.Id,
                    Items = drink
                };

            var food = c.Items.Where(i => !i.IsDrink).ToList();
            if (food.Any())
                yield return new FoodOrdered
                {
                    Id = c.Id,
                    Items = food
                };
        }

        public IEnumerable Handle(MarkDrinksServed c)
        {
            if (!AreDrinksOutstanding(c.MenuNumbers))
                throw new DrinksNotOutstanding();

            yield return new DrinksServed
            {
                Id = c.Id,
                MenuNumbers = c.MenuNumbers
            };
        }

        public IEnumerable Handle(CloseTab c)
        {
            yield return new TabClosed
            {
                Id = c.Id,
                AmountPaid = c.AmountPaid,
                OrderValue = servedItemsValue,
                TipValue = c.AmountPaid - servedItemsValue
            };
        }

        private bool AreDrinksOutstanding(List<int> menuNumbers)
        {
            return AreAllInList(want: menuNumbers, have: outstandingDrinks);
        }

        private bool IsFoodOutstanding(List<int> menuNumbers)
        {
            return AreAllInList(want: menuNumbers, have: outstandingFood);
        }

        private bool IsFoodPrepared(List<int> menuNumbers)
        {
            return AreAllInList(want: menuNumbers, have: preparedFood);
        }

        private static bool AreAllInList(List<int> want, List<OrderedItem> have)
        {
            var curHave = new List<int>(have.Select(i => i.MenuNumber));
            foreach (var num in want)
                if (curHave.Contains(num))
                    curHave.Remove(num);
                else
                    return false;
            return true;
        }

    }
}
