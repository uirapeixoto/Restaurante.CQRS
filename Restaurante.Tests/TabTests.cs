using NUnit.Framework;
using Restaurante.Command;
using Restaurante.Dominio.Mesa;
using Restaurante.Dominio.Pedido;
using Restaurante.Dominio.Restaurante;
using Restaurante.Events;
using Restaurante.Events.Mesas;
using System;
using System.Collections.Generic;

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

        [Test]
        public void PodeAbrirUmaNovaMesa()
        {
            Test(
                Given(),
                When(new OpenTab
                {
                    Id = _testId,
                    TableNumber = _testTable,
                    Waiter = _testWaiter
                }),
                Then(new TabOpened
                {
                    Id = _testId,
                    TableNumber = _testTable,
                    Waiter = _testWaiter
                }));
        }

        [Test]
        public void NaoPodeAbrirComMesaFechada()
        {
            Test(
                Given(),
                When(new PlaceOrder
                {
                    Id = _testId,
                    Items = new List<OrderedItem>{

                        _testDrink1
                    }
                }),
                ThenFailWith<TabNotOpen>());
        }

        [Test]
        public void PodeColocarPedidoDeBebidas()
        {
            Test(
                Given(new TabOpened
                {
                    Id = _testId,
                    TableNumber = _testTable,
                    Waiter = _testWaiter
                }),
                When(new PlaceOrder
                {
                    Id = _testId,
                    Items = new List<OrderedItem> { _testDrink1, _testDrink2 }
                }),
                Then(new DrinksOrdered
                {
                    Id = _testId,
                    Items = new List<OrderedItem> { _testDrink1, _testDrink2 }
                }));
        }
        [Test]
        public void NaoPodeColocarPedidoComida()
        {
            Test(
                Given(new TabOpened
                {
                    Id = _testId,
                    TableNumber = _testTable,
                    Waiter = _testWaiter
                }),
                When(new PlaceOrder
                {
                    Id = _testId,
                    Items = new List<OrderedItem> { _testFood1, _testFood1 }
                }),
                Then(new FoodOrdered
                {
                    Id = _testId,
                    Items = new List<OrderedItem> { _testFood1, _testFood1 }
                }
            ));
        }
        [Test]
        public void PodeColocarPedidoComidaEBebida()
        {
            Test(
        Given(new TabOpened
        {
            Id = _testId,
            TableNumber = _testTable,
            Waiter = _testWaiter
        }),
        When(new PlaceOrder
        {
            Id = _testId,
            Items = new List<OrderedItem> { _testFood1, _testDrink2 }
        }),
        Then(new DrinksOrdered
        {
            Id = _testId,
            Items = new List<OrderedItem> { _testDrink2 }
        },
        new FoodOrdered
        {
            Id = _testId,
            Items = new List<OrderedItem> { _testFood1 }
        }));
        }

        [Test]
        public void PedidoBebidaPodeSerServido()
        {
            Test(
                Given(new TabOpened
                {
                    Id = _testId,
                    TableNumber = _testTable,
                    Waiter = _testWaiter
                },
                new DrinksOrdered
                {
                    Id = _testId,
                    Items = new List<OrderedItem> { _testDrink1, _testDrink2 }
                }),
                When(new MarkDrinksServed
                {
                    Id = _testId,
                    MenuNumbers = new List<int>
                        { _testDrink1.MenuNumber, _testDrink2.MenuNumber }
                }),
                Then(new DrinksServed
                {
                    Id = _testId,
                    MenuNumbers = new List<int>
                        { _testDrink1.MenuNumber, _testDrink2.MenuNumber }
                }));
        }

        [Test]
        public void NaoPodeServirUmaBebidaSemPedido()
        {
            Test(
                Given(new TabOpened
                {
                    Id = _testId,
                    TableNumber = _testTable,
                    Waiter = _testWaiter
                },
                new DrinksOrdered
                {
                    Id = _testId,
                    Items = new List<OrderedItem> { _testDrink1 }
                }),
                When(new MarkDrinksServed
                {
                    Id = _testId,
                    MenuNumbers = new List<int> { _testDrink2.MenuNumber }
                }),
                ThenFailWith<DrinksNotOutstanding>());
        }

        [Test]
        public void NaoPodeServirUmPedidoDeBebidaDuasVezes()
        {
            Test(
                Given(new TabOpened
                {
                    Id = _testId,
                    TableNumber = _testTable,
                    Waiter = _testWaiter
                },
                new DrinksOrdered
                {
                    Id = _testId,
                    Items = new List<OrderedItem> { _testDrink1 }
                },
                new DrinksServed
                {
                    Id = _testId,
                    MenuNumbers = new List<int> { _testDrink1.MenuNumber }
                }),
                When(new MarkDrinksServed
                {
                    Id = _testId,
                    MenuNumbers = new List<int> { _testDrink1.MenuNumber }
                }),
                ThenFailWith<DrinksNotOutstanding>());
        }

    }
}
