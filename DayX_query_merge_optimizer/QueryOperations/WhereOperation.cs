using System.Linq.Expressions;

namespace DayX_query_merge_optimizer.QueryOperations
{
    public sealed class WhereOperation<T> : QueryOperation
    {
        public Expression<Func<T, bool>> Predicate { get; }

        public WhereOperation(Expression<Func<T, bool>> predicate) : base(QueryOperationType.Where)
        {
            Predicate = predicate;
        }
    }
}
