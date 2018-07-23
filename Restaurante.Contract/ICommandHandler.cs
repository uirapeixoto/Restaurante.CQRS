namespace Restaurante.Contract
{
    public interface ICommandHandler<TCommand>
    {
        void Handle(TCommand c);
    }

    public interface ICommandHandler<in TCommand, out TCommandResult> where TCommand : ICommand
    {
        TCommandResult Handle(TCommand c);
    }
}
