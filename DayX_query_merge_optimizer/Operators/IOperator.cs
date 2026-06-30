namespace DayX_query_merge_optimizer.Operators
{
    public interface IOperator<T>
    {
        IEnumerable<T> Execute(IEnumerable<T> source);
    }
}
