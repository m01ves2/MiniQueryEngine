namespace Day9_execution
{
    public class QueryEngine
    {
        private readonly QueryValidator validator;

        public QueryEngine()
        {
            validator = new QueryValidator();
        }

        public Query<T> Query<T>()
        {
            return new Query<T>(this);
        }

        public IEnumerable<T> Execute<T>(IEnumerable<T> source, Query<T> query)
        {
            var ops = query.Build();

            //validator.Validate(ops);

            IQueryExecutor<T> executor = new PipelineExecutor<T>();

            return executor.Execute(source, ops);
        }
    }
}
