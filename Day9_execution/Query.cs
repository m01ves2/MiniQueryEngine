using System.Linq.Expressions;

namespace Day9_execution
{
    public class Query<T>
    {
        private readonly List<Expression<Func<T, bool>>> expressions = new List<Expression<Func<T, bool>>>();

        public Query<T> Where(Expression<Func<T, bool>> expr)
        {
            expressions.Add(expr);
            return this;
        }

        public IEnumerable<T> Execute(IEnumerable<T> collection)
        {
            List<Func<T, bool>> funcs = new List<Func<T, bool>>();
            foreach (var expression in expressions) {
                funcs.Add(expression.Compile());
            }

            foreach (var item in collection) {
                bool isAllTrue = true;
                foreach (var func in funcs) {
                    if (!func(item)) {
                        isAllTrue = false;
                        break;
                    }

                }

                if (isAllTrue) {
                    yield return item;
                }
            }
        }

    }
}
