namespace DayX_query_merge_optimizer
{
    public class QueryEngine
    {

        public QueryEngine()
        {
        }

        public Query<T> Query<T>()
        {
            return new Query<T>(this);
        }
    }
}
