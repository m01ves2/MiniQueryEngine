using System.Linq.Expressions;
using Day9_execution.Operations;

namespace Day9_execution
{
    public class Query<T>
    {
        private readonly List<IOperation<T>> operations = new List<IOperation<T>>();

        public Query<T> Where(Expression<Func<T, bool>> expr)
        {
            operations.Add(new WhereOperator<T>(expr.Compile()));
            return this;
        }

        public IEnumerable<T> Execute(IEnumerable<T> source)
        {
            foreach (var op in operations) {
                source = op.Execute(source);
            }

            return source;
        }
    }
}
