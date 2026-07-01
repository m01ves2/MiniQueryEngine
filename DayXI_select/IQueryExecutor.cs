using DayXI_select.QueryOperations;

namespace DayXI_select
{
    public interface IQueryExecutor<T>
    {
        IEnumerable<object> Execute(IEnumerable<T> source, IReadOnlyList<QueryOperation> operations);
    }
}
