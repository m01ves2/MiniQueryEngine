using System.Linq.Expressions;

namespace DayXI_select.QueryOperations
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
