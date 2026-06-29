using Day9_execution.QueryOperations;

namespace Day9_execution
{
    public class QueryValidator
    {
        public void Validate(IReadOnlyList<QueryOperation> ops)
        {
            int terminalIndex = ops.Select((op, i) => (op, i)).FirstOrDefault(x => IsTerminal(x.op)).i;

            if (terminalIndex != 0 && terminalIndex != ops.Count - 1)
                throw new Exception("Terminal operation must be last");
        }

        private bool IsTerminal(QueryOperation op)
        {
            return op.Type == QueryOperationType.Count;
        }
    }
}
