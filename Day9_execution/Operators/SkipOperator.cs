
namespace Day9_execution.Operators
{
    public class SkipOperator<T> : IOperator<T>
    {
        private int count = 0;
        public SkipOperator(int count)
        {
            this.count = count;
        }
        public IEnumerable<T> Execute(IEnumerable<T> source)
        {
            //foreach (var item in source) {
            //    if (--count < 0)
            //        yield break;

            //    yield return item;
            //}

            int remaining = count;

            foreach (var item in source) {
                if (--remaining >= 0)
                    continue;

                yield return item;
            }
        }
    }
}
