namespace DayX_query_merge_optimizer.QueryOperations
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
