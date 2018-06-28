using Restaurante.Command.Cozinha.Result;
using Restaurante.Contract;
using System.Collections.Generic;
using System.Linq;

namespace Restaurante.Command.Cozinha.Handler
{
    public class RemoverTarefaCozinhaCommandHandler : ICommandHandler<TodoListItemCommand>
    {
        private IList<TodoListGroupCommandResult> _group;

        public RemoverTarefaCozinhaCommandHandler(List<TodoListGroupCommandResult> todoListItem)
        {
            _group = todoListItem;
        }

        public IEnumerable<TodoListGroupCommandResult> Get()
        {
            return _group;
        }

        public void Handle(TodoListItemCommand command)
        {
            var groupItem = new TodoListGroupCommandResult
            {
                Tab = command.Id,
                Items = new List<TodoListItemCommandResult>(
                command.Items.Select(i => new TodoListItemCommandResult
                {
                    MenuNumber = i.MenuNumber,
                    Description = i.Description
                }))
            };

            _group.Remove(groupItem);
        }
    }
}
