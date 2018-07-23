using Restaurante.Contract;
using System;

namespace Restaurante.Command.Cozinha.Command
{
    public class MarcarComoProntoCommand : ICommand
    {
        public int Id { get; }
        public DateTime AServir { get; }

        public MarcarComoProntoCommand(int id, DateTime aServir)
        {
            Id = id;
            AServir = aServir;
        }
    }
}
