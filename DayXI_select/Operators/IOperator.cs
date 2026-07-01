namespace DayXI_select.Operators
{
    public interface IOperator<T>
    {
        IEnumerable<object> Execute(IEnumerable<T> source);
    }
}
