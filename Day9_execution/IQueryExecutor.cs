using Day9_execution.QueryOperations;

namespace Day9_execution
{
    public interface IQueryExecutor<T>
    {
        IEnumerable<T> Execute(IEnumerable<T> source, IReadOnlyList<QueryOperation> operations);
    }
}
