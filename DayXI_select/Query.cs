using System.Linq.Expressions;
using DayXI_select.QueryOperations;

namespace DayXI_select
{    public class Query<T>
    {
        private readonly QueryEngine engine;
        private List<QueryOperation> operations = new();

        public Query(QueryEngine engine)
        {
            this.engine = engine;
        }

        public IEnumerable<object> Execute(IEnumerable<T> source)
        {
            var validator = new QueryValidator();
            //validator.Validate(ops);

            var optimizer = new QueryOptimizer<T>();
            operations = optimizer.Optimize(operations).ToList();

            var executor = new PipelineExecutor<T>();
            var result = executor.Execute(source, operations);
            return result;
        }


        public Query<T> Where(Expression<Func<T, bool>> expr)
        {
            operations.Add(new WhereOperation<T>(expr));
            return this;
        }

        public Query<T> Skip(int count)
        {
            operations.Add(new SkipOperation(count));
            return this;
        }

        public Query<T> Take(int count)
        {
            operations.Add(new TakeOperation(count));
            return this;
        }

        public Query<T> Select(Expression<Func<T, object>> selector)
        {
            operations.Add(new SelectOperation<T>(selector));
            return this;
        }

        public IReadOnlyList<QueryOperation> Build() => operations;
    }
}
