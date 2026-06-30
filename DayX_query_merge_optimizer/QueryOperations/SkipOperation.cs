namespace DayX_query_merge_optimizer.QueryOperations
{
    public sealed class SkipOperation : QueryOperation
    {
        public int Count { get; }

        public SkipOperation(int count) : base(QueryOperationType.Skip)
        {
            Count = count;
        }
    }
}
