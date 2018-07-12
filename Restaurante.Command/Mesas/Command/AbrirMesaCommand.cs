using Restaurante.Contract;
using Restaurante.Dominio;
using System;

namespace Restaurante.Command.Mesas.Command
{
    public class AbrirMesaCommand : ICommand
    { 
        public int NumMesa { get; }
        public int GarcomId { get; }
        public bool Ativo { get; }
        public DateTime DataServico { get; }

        public AbrirMesaCommand(int numMesa, int garcomId)
        {
            NumMesa = numMesa;
            GarcomId = garcomId;
            Ativo = true;
            DataServico = DateTime.Now ;
        }
    }
}
