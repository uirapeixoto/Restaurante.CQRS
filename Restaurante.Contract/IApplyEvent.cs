namespace Restaurante.Contract
{
    /// <summary>
    /// Implementado por um agregado uma vez para cada tipo de evento, ele pode ser aplicado.
    /// </summary>
    /// <typeparam name="TEvent"></typeparam>
    public interface IApplyEvent<TEvent>
    {
        void Apply(TEvent e);
    }
}
