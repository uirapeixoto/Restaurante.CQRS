using Restaurante.Command.Mesas.Command;
using Restaurante.Contract;
using Restaurante.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Command.Mesas.Handler
{
    public class MarcarComoProntoCommandHandler : ICommandHandler<MarcarComoProntoCommand>
    {
        readonly ICafeContext _context;

        public MarcarComoProntoCommandHandler(ICafeContext context)
        {
            _context = context;
        }

        protected bool BusinessValidation(int id)
        {
            var result = _context.TB_ORDERED_ITEM.Where(x => x.ID == id);
            if (result.Any())
            {
                return true;
            }
            return false;
        }

        public void Handle(MarcarComoProntoCommand c)
        {
            try
            {
                if (BusinessValidation(c.Id))
                {
                    var registro = _context.TB_ORDERED_ITEM.Where(x => x.ID == c.Id).FirstOrDefault();
                    registro.DT_TO_SERVE = c.DataPronto;
                    
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
