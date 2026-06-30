namespace DayX_query_merge_optimizer.QueryOperations
{
    public sealed class TakeOperation : QueryOperation
    {
        public int Count { get; }

        public TakeOperation(int count) : base(QueryOperationType.Take)
        {
            Count = count;
        }
    }
}
