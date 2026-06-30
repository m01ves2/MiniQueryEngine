using DayX_query_merge_optimizer.QueryOperations;

namespace DayX_query_merge_optimizer
{
    public interface IQueryExecutor<T>
    {
        IEnumerable<T> Execute(IEnumerable<T> source, IReadOnlyList<QueryOperation> operations);
    }
}
