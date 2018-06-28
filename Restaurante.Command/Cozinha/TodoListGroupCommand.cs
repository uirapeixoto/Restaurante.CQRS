using Restaurante.Command.Cozinha.Result;
using Restaurante.Contract;
using System.Collections.Generic;

namespace Restaurante.Command.Cozinha
{
    public class TodoListGroupCommand : ICommand
    {
        public int Tab;
        public List<TodoListItemCommandResult> Items;
    }
}
