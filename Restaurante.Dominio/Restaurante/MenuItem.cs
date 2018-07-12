using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Dominio
{
    public class MenuItem
    {
        public int Id { get; set; }
        public int NumMenuItem {get; set;}
        public string Descricao { get; set; }
        public bool Bebida { get; set; }
        public bool Ativo { get; set; }

    }
}
