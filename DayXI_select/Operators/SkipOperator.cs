namespace DayXI_select.Operators
{
    public class SkipOperator<T> : IOperator<T>
    {
        private int count = 0;
        public SkipOperator(int count)
        {
            this.count = count;
        }
        public IEnumerable<object> Execute(IEnumerable<T> source)
        {
            int remaining = count;

            foreach (var item in source) {
                if (--remaining >= 0)
                    continue;

                yield return item;
            }
        }
    }
}
