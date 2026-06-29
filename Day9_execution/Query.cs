using System.Linq.Expressions;
using Day9_execution.Operators;
using Day9_execution.QueryOperations;

namespace Day9_execution
{    public class Query<T>
    {
        private readonly QueryEngine engine;
        private readonly List<QueryOperation> operations = new();

        public Query(QueryEngine engine)
        {
            this.engine = engine;
        }

        public IEnumerable<T> Execute(IEnumerable<T> source)
        {
            var executor = new PipelineExecutor<T>();
            return executor.Execute(source, operations);
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

        public IReadOnlyList<QueryOperation> Build() => operations;
    }
}
