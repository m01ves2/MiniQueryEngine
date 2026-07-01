namespace DayXI_select.Operators
{
    public class TakeOperator<T> : IOperator<T>
    {
        private int count = 0;
        public TakeOperator(int count)
        {
            this.count = count;
        }
        public IEnumerable<object> Execute(IEnumerable<T> source)
        {
            int remaining = count;

            foreach (var item in source) {
                if (--remaining < 0)
                    yield break;

                yield return item;
            }
        }
    }
}
