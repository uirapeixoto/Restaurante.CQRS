using Restaurante.Contract;
using Restaurante.Infra.Models;
using System.Linq;

namespace Restaurante.Command.Cozinha.Handler
{
    public class IncluirPedidoComidaTarefaCommandHandler : ICommandHandler<FoodOrderedCommand>
    {
        public TodoListMock _context;
        public IncluirPedidoComidaTarefaCommandHandler(TodoListMock context)
        {
            _context = context;
        }

        public void Handle(FoodOrderedCommand command)
        {
            var mesa = _context.GetList()
                .Select(e => e.Pedidos.Where( p => p.Id == command.PedidoId))
                .FirstOrDefault();
        }
    }
}
