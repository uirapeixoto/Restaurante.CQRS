using Restaurante.Contract;
using System.Collections.Generic;

namespace Restaurante.Command.Mesas.Command
{
    public class PedidoCommand : ICommand
    {
        public int MesaId { get; }
        public IList<PedidoItemCommand> PedidosBebidaItens{ get; }
        public IList<PedidoItemCommand> PedidosComidaItens { get; }

        public PedidoCommand(
            int mesaId,
            IList<PedidoItemCommand> pedidosBebidaItens,
            IList<PedidoItemCommand> pedidosComidaItens
            )
        {
            MesaId = mesaId;
            PedidosBebidaItens = pedidosBebidaItens;
            PedidosComidaItens = pedidosComidaItens;
        }
    }
}
