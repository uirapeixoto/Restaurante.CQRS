﻿using Restaurante.Contract;
using System;

namespace Restaurante.Command.Mesas.Command
{
    public sealed class PedidoItemCommand : ICommand
    {
        public int MenuId { get; }
        public string Descricao { get; }
        public int Quantidade { get; }
        public decimal Ajuste { get; }
        public DateTime? AServir { get; }
        public DateTime? EmPreparacao { get; }
        public DateTime? Servido { get; }

        public DateTime DataServico {
            get
            {
                return DateTime.Now;
            }
        }

        public PedidoItemCommand(int menuId, string descricao, int quantidade, DateTime? aServir, DateTime? emPreparacao, DateTime? servido, decimal ajuste = (decimal) 0.0)
        {
            MenuId = menuId;
            Descricao = descricao;
            Quantidade = quantidade;
            AServir = aServir;
            EmPreparacao = emPreparacao;
            Servido = servido;
            Ajuste = ajuste;
        }
    }
}
