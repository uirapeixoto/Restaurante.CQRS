﻿using Restaurante.Contract;
using System;

namespace Restaurante.Query.Result
{
    public sealed class PedidoItemQueryResult : IQueryResult
    {
        public int Id {get;}
        public string Descricao { get; }
        public int Quantidade { get; }
        public decimal AjustePreco { get; }
        public DateTime? AServir { get; }
        public DateTime? EmPreparacao { get; }
        public DateTime? Servido { get; }
        public MenuItemQueryResult MenuItem { get; }

        public PedidoItemQueryResult(int id, MenuItemQueryResult menuItem, int quantidade, DateTime? aServir, DateTime? emPreparacao, DateTime? servido, decimal ajustePreco = (decimal) 0.0, string descricao = "" )
        {
            Id = id;
            MenuItem = menuItem;
            Quantidade = quantidade;
            AServir = aServir;
            EmPreparacao = emPreparacao;
            Servido = servido;
            AjustePreco = ajustePreco;
            Descricao = descricao;
        }

    }
}