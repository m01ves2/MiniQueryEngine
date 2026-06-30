using DayX_query_merge_optimizer.QueryOperations;

namespace DayX_query_merge_optimizer
{
    public class QueryValidator
    {
        public void Validate(IReadOnlyList<QueryOperation> ops)
        {
            throw new NotImplementedException("Validation rules will be defined in Day-10 merge tree stage");
        }

        private bool IsTerminal(QueryOperation op)
        {
            return op.Type == QueryOperationType.Count;
        }
    }
}
