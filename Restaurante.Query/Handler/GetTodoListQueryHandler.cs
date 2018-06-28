using Restaurante.Contract;
using Restaurante.Infra.Models;
using Restaurante.Query.Result;
using System.Collections.Generic;
using System.Linq;

namespace Restaurante.Query.Handler
{
    public class GetTodoListQueryHandler : IQueryHandler<TodoListItemQuery, IEnumerable<TodoListGroupQueryResult>>
    {
        private List<TodoListGroupQueryResult> todoList = new List<TodoListGroupQueryResult>();

        private TodoListMock _context;

        public GetTodoListQueryHandler(TodoListMock context)
        {
            _context = context;
        }

        IEnumerable<TodoListGroupQueryResult> IQueryHandler<TodoListItemQuery, IEnumerable<TodoListGroupQueryResult>>.Handle(TodoListItemQuery query)
        {
            return todoList.Select(e => new TodoListGroupQueryResult
            {
                Tab = e.Tab,
                Items = new List<TodoListItemQueryResult>(e.Items)
            });
        }
    }
}
