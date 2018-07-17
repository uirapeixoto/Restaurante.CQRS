using Restaurante.Contract;
using System;

namespace Restaurante.Command.Mesas.Command
{
    public class MarcarComoProntoCommand : ICommand
    {
        public int Id { get; }
        public DateTime? DataPronto { get; }
        public MarcarComoProntoCommand(int id, DateTime? dataPronto)
        {
            Id = id;
            DataPronto = dataPronto;
        }
    }
}
