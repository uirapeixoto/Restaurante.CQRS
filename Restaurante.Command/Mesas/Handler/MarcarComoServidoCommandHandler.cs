using Restaurante.Command.Mesas.Command;
using Restaurante.Contract;
using Restaurante.Infra.Context;
using System;
using System.Linq;

namespace Restaurante.Command.Mesas.Handler
{
    public class MarcarComoServidoCommandHandler : ICommandHandler<MarcarComoServidoCommand>
    {
        readonly ICafeContext _context;

        public MarcarComoServidoCommandHandler(ICafeContext context)
        {
            _context = context;
        }

        protected bool BusinessValidation(int id)
        {
            var result = _context.TB_ORDERED_ITEM.Where(x => x.ID == id);
            if(result.Any())
            {
                return true;
            }
            return false;
        }

        public void Handle(MarcarComoServidoCommand c)
        {
            try
            {
                if (BusinessValidation(c.Id))
                {
                    var registro = _context.TB_ORDERED_ITEM.Where(x => x.ID == c.Id).FirstOrDefault();
                    registro.DT_SERVED = c.DataServido;
                    var db = new CafeContext();
                    _context.Entry(registro).State = System.Data.Entity.EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
