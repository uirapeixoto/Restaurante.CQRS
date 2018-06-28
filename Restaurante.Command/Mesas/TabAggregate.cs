using Restaurante.Contract;
using Restaurante.Dominio.Mesa;
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
        private List<int> outstandingDrinks = new List<int>();

        public void Apply(TabOpened e)
        {
            _open = true;
        }

        public void Apply(DrinksOrdered e)
        {
            outstandingDrinks.AddRange(e.Items.Select(i => i.MenuNumber));
        }

        public void Apply(DrinksServed e)
        {
            foreach (var num in e.MenuNumbers)
                outstandingDrinks.Remove(num);
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

        private bool AreDrinksOutstanding(List<int> menuNumbers)
        {
            var curOutstanding = new List<int>(outstandingDrinks);
            foreach (var num in menuNumbers)
                if (curOutstanding.Contains(num))
                    curOutstanding.Remove(num);
                else
                    return false;
            return true;
        }

    }
}
