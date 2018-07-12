using System;
using System.Collections.Generic;
using Restaurante.Dominio;

namespace Restaurante.Dominio
{
    public class MesaAberta
    {
        public int Id { get; set; }
        public int NumMesa { get; set; }
        public Garcom Garcom { get; set; }
        public IEnumerable<Pedido> Pedidos { get; set; }
        public DateTime? DataServico { get; set; }
        public bool Ativo { get; set; }
    }
}
