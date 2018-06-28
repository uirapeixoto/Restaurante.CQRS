namespace Restaurante.Contract
{
    public interface IQueryHandler<out TQueryResult>
    {
        TQueryResult Handle();
    }

    public interface IQueryHandler<in TQuery, out TQueryResult> where TQuery : IQuery
    {
        TQueryResult Handle(TQuery query);
    }
}
