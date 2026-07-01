namespace DayXI_select
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

        //public IEnumerable<T> Execute<T>(IEnumerable<T> source, Query<T> query)
        //{
        //    var operations = query.Build();

        //    var validator = new QueryValidator();
        //    // validator.Validate(operations);

        //    var optimizer = new QueryOptimizer<T>();
        //    operations = optimizer.Optimize(operations).ToList();

        //    var executor = new PipelineExecutor<T>();

        //    return executor.Execute(source, operations);
        //}
    }
}
