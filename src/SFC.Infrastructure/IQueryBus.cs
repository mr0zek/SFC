namespace SFC.Infrastructure
{
  public interface IQ<TResponse,TRequest>
  {
  }


  public interface IQueryBus
  {
    TQueryResponse Query<TQueryResponse, TQueryRequest>(TQueryRequest request);
  }
}