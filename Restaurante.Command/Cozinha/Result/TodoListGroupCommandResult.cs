using Restaurante.Contract;
using System;
using System.Collections.Generic;

namespace Restaurante.Command.Cozinha.Result
{
    public class TodoListGroupCommandResult : ICommandResult
    {
        public Guid Tab;
        public List<TodoListItemCommandResult> Items;
    }
}
