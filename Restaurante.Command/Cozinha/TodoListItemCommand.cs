

using Restaurante.Command.Cozinha.Result;
using Restaurante.Contract;
using System;
using System.Collections.Generic;

namespace Restaurante.Command.Cozinha
{
    public class TodoListItemCommand : ICommand
    {
        public Guid Id;
        public List<OrderedItemCommandResult> Items;
    }
}
