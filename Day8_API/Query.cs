using System.Linq.Expressions;

namespace Day8_API
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
            throw new NotImplementedException();
        }

    }
}
