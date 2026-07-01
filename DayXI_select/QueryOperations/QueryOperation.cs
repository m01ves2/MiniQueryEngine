namespace DayXI_select.QueryOperations
{
    public abstract class QueryOperation
    {
        public QueryOperationType Type { get; }

        protected QueryOperation(QueryOperationType type)
        {
            Type = type;
        }
    }
}
