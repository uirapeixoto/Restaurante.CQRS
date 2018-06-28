using System.Collections;
using System.Collections.Generic;

namespace Restaurante.Contract
{
    public interface IHandleCommand<TCommand>
    {
        IEnumerable Handle(TCommand c);
    }

    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        void Handle(TCommand command);
        
    }
}
