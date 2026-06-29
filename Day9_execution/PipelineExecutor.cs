using Day9_execution.Operators;
using Day9_execution.QueryOperations;

namespace Day9_execution
{
    public class PipelineExecutor<T> : IQueryExecutor<T>
    {
        public IEnumerable<T> Execute( IEnumerable<T> source, IReadOnlyList<QueryOperation> operations)
        {
            foreach (var op in operations) {
                source = Apply(source, op);
            }

            return source;
        }

        private IEnumerable<T> Apply( IEnumerable<T> source, QueryOperation op)
        {
            return op switch
            {
                //WhereOperation<T> where => source.Where(where.Predicate.Compile()),
                WhereOperation<T> where => new WhereOperator<T>(where.Predicate.Compile()).Execute(source),

                //SkipOperation skip => source.Skip(skip.Count),
                SkipOperation skip => new SkipOperator<T>(skip.Count).Execute(source),

                //TakeOperation take => source.Take(take.Count),
                TakeOperation take => new TakeOperator<T>(take.Count).Execute(source),

                _ => throw new NotSupportedException($"Operation {op.GetType().Name} not supported")
            };
        }
    }
}
