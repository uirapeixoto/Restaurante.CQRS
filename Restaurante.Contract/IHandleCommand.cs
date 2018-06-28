using System.Collections;

namespace Restaurante.Contract
{
    public interface IHandleCommand<TCommand>
    {
        IEnumerable Handle(TCommand c);
    }
}
