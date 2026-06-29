namespace Day9_execution.Operations
{
    public class WhereOperator<T> : IOperation<T>
    {
        private readonly Func<T, bool> predicate;

        public WhereOperator(Func<T, bool> predicate)
        {
            this.predicate = predicate;
        }

        public IEnumerable<T> Execute(IEnumerable<T> source)
        {
            foreach (var item in source) {
                if (predicate(item))
                    yield return item;
            }
        }
    }
}
