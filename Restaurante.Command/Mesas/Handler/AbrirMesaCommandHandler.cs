using Restaurante.Command.Mesas.Command;
using Restaurante.Command.Mesas.CommandResult;
using Restaurante.Contract;
using Restaurante.Infra.Context;
using System;
using System.Linq;

namespace Restaurante.Command.Mesas.Handler
{
    public class AbrirMesaCommandHandler : ICommandHandler<AbrirMesaCommand, AbrirMesaCommandResult>
    {
        private ICafeContext _context;

        public AbrirMesaCommandHandler(ICafeContext context)
        {
            _context = context;
        }

        public bool Validacao(int numMesa)
        {
                return !_context.TB_TAB_OPENED
                .Where(x => x.NU_TABLE == numMesa)
                .Where(x => x.ST_ACTIVE).Any();
        }

        public AbrirMesaCommandResult Handle(AbrirMesaCommand c)
        {
            try
            {
                if(Validacao(c.NumMesa))
                {
                    var table = new TB_TAB_OPENED
                    {
                        NU_TABLE = c.NumMesa,
                        ID_WAITER = c.GarcomId,
                        ST_ACTIVE = c.Ativo,
                        DT_SERVICE = c.DataServico,
                        ST_UNIQUE_IDENTIFIER = Guid.NewGuid()
                    };

                    _context.TB_TAB_OPENED.Add(table);
                    var id = _context.SaveChanges();

                    return _context.TB_TAB_OPENED
                        .AsNoTracking()
                        .AsParallel()
                        .Where(x => x.ID == table.ID)
                        .Select(o => new AbrirMesaCommandResult(o.ID, o.NU_TABLE.Value, o.ID_WAITER.Value, o.ST_ACTIVE, o.DT_SERVICE.Value))
                        .FirstOrDefault();
                }
                else
                {
                    throw new Exception("Essa mesa já está aberta");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
