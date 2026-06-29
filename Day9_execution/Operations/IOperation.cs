namespace Day9_execution.Operations
{
    public interface IOperation<T>
    {
        IEnumerable<T> Execute(IEnumerable<T> source);
    }
}
