using NUnit.Framework;
using Restaurante.Command;
using Restaurante.Dominio.Pedido;
using System;

namespace Restaurante.Tests
{
    [TestFixture]
    public class TabTests : BDDTest<TabAggregate>
    {
        private Guid _testId;
        private int _testTable;
        private string _testWaiter;
        private OrderedItem _testDrink1;
        private OrderedItem _testDrink2;
        private OrderedItem _testFood1;
        private OrderedItem _testFood2;

        [SetUp]
        public void Setup()
        {
            _testId = Guid.NewGuid();
            _testTable = 42;
            _testWaiter = "Derek";

            _testDrink1 = new OrderedItem
            {
                MenuNumber = 4,
                Description = "Sprite",
                Price = 1.50M,
                IsDrink = true
            };
            _testDrink2 = new OrderedItem
            {
                MenuNumber = 10,
                Description = "Beer",
                Price = 2.50M,
                IsDrink = true
            };

            _testFood1 = new OrderedItem
            {
                MenuNumber = 16,
                Description = "Beef Noodles",
                Price = 7.50M,
                IsDrink = false
            };
            _testFood2 = new OrderedItem
            {
                MenuNumber = 25,
                Description = "Vegetable Curry",
                Price = 6.00M,
                IsDrink = false
            };
        }
    }
}
