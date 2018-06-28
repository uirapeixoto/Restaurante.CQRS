namespace Restaurante.Contract
{
    /// <summary>
    /// Implementado por qualquer coisa que deseje assinar um evento emitido por
    /// um agregado e armazenado com sucesso.
    /// </summary>
    /// <typeparam name="TEvent"></typeparam>
    public interface ISubscribeTo<TEvent>
    {
        void Handle(TEvent e);
    }
}
