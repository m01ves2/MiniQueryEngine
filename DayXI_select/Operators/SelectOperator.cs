namespace DayXI_select.Operators
{
    public class SelectOperator<T> : IOperator<T>
    {
        private readonly Func<T, object> selector;

        //public Expression<Func<T, object>> Selector { get; }

        public SelectOperator(Func<T, object> selector)
        {
            this.selector = selector;
        }

        public IEnumerable<object> Execute(IEnumerable<T> source)
        {
            foreach (var item in source)
                yield return selector(item);
        }
    }
}
