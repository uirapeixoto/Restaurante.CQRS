using System;
using System.Collections.Generic;

namespace Restaurante.Infra.Models
{
    public class TodoListMock
    {
        public Guid Tab { get; set; }

        public IEnumerable<Pedido> Pedidos { get; set; }
        
        public IEnumerable<TodoListMock> GetList()
        {
            return new List<TodoListMock>
            {
                new TodoListMock{
                    Tab = Guid.NewGuid(),
                    Pedidos = new List<Pedido>
                    {
                        new Pedido
                        {
                            Id = Guid.NewGuid(),
                            Itens = new List<Item>
                            {
                                new Item(1,"Heineken", true, 6.9m),
                                new Item(1,"Heineken", true, 6.9m),
                                new Item(2,"Budweiser", true, 6.9m),
                                new Item(2,"Budweiser", true, 6.9m),
                                new Item(4,"Porção de Pastel(12)", true, 6.9m)
                            }
                        }
                    }
                },
                new TodoListMock
                {
                    Tab = Guid.NewGuid(),
                    Pedidos = new List<Pedido>
                    {
                        new Pedido
                        {
                            Id = Guid.NewGuid(),
                            Itens = new List<Item>
                            {
                                new Item(2,"Budweiser", true, 6.9m),
                                new Item(2,"Budweiser", true, 6.9m),
                                new Item(5,"Bata Frita média", true, 14.9m),
                            }
                        }
                    },
                },
                new TodoListMock
                {
                    Tab = Guid.NewGuid(),
                    Pedidos = new List<Pedido>
                    {
                        new Pedido
                        {
                            Id = Guid.NewGuid(),
                            Itens = new List<Item>
                            {
                                new Item(2,"Budweiser", true, 6.9m),
                                new Item(2,"Budweiser", true, 6.9m),
                                new Item(1,"Heineken", true, 6.9m),
                                new Item(6,"Bata Frita grande", true, 17.9m)
                            }
                        }
                    }
                },
                new TodoListMock
                {
                    Tab = Guid.NewGuid(),
                    Pedidos = new List<Pedido>
                    {
                        new Pedido
                        {
                            Id = Guid.NewGuid(),
                            Itens = new List<Item>
                            {
                                new Item(2,"Budweiser", true, 6.9m),
                                new Item(2,"Budweiser", true, 6.9m),
                                new Item(2,"Budweiser", true, 6.9m),
                                new Item(1,"Heineken", true, 6.9m),
                                new Item(1,"Heineken", true, 6.9m),
                                new Item(1,"Heineken", true, 6.9m),
                                new Item(6,"Bata Frita grande", true, 17.9m)
                            }
                        }
                    }
                }
            };
        }
    }
}
