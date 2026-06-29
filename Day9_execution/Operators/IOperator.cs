namespace Day9_execution.Operators
{
    public interface IOperator<T>
    {
        IEnumerable<T> Execute(IEnumerable<T> source);
    }
}
