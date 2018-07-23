using Restaurante.Contract;
using System;

namespace Restaurante.Command.Mesas.Command
{
    public class MarcarComoServidoCommand : ICommand
    {
        public int Id { get; }
        public DateTime? DataServido { get; }
        public MarcarComoServidoCommand(int id, DateTime? dataServido)
        {
            Id = id;
            DataServido = dataServido;
        }
    }
}
