using Restaurante.Command.Cozinha.Command;
using Restaurante.Contract;
using Restaurante.Infra.Context;
using System;
using System.Linq;

namespace Restaurante.Command.Cozinha.Handler
{
    public class MarcarComoProntoCommandHandler : ICommandHandler<MarcarComoProntoCommand>
    {
        readonly ICafeContext _context;

        public MarcarComoProntoCommandHandler(ICafeContext context)
        {
            _context = context;
        }

        public void Handle(MarcarComoProntoCommand c)
        {
            try
            {

                var registro = _context.TB_ORDERED_ITEM.Where(x => x.ID == c.Id).FirstOrDefault();
                registro.DT_TO_SERVE = c.AServir;

                _context.Entry(registro).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
