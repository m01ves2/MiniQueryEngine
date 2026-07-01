using DayXI_select.QueryOperations;

namespace DayXI_select
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
