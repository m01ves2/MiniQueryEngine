using System.Linq.Expressions;

namespace DayXI_select.QueryOperations
{
    public sealed class SelectOperation<T> : QueryOperation
    {
        public LambdaExpression Selector { get; }

        public SelectOperation(LambdaExpression selector) : base(QueryOperationType.Select)
        {
            Selector = selector;
        }
    }
}
