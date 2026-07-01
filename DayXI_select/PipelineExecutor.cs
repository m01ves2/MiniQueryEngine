using DayXI_select.Operators;
using DayXI_select.QueryOperations;

namespace DayXI_select
{
    public class PipelineExecutor<T> : IQueryExecutor<T>
    {
        public IEnumerable<object> Execute(IEnumerable<T> source, IReadOnlyList<QueryOperation> operations)
        {
            IEnumerable<object> result = source.Cast<object>();

            foreach (var op in operations) {
                var operatorInstance = CreateOperator(op);
                result = operatorInstance.Execute(result);
            }

            return result;
        }

        private IEnumerable<object> Apply(IEnumerable<object> source, QueryOperation op)
        {
            var typed = source.Cast<T>();

            return op switch
            {
                WhereOperation<T> where => new WhereOperator<T>(where.Predicate.Compile()).Execute(typed).Cast<object>(),

                SkipOperation skip => new SkipOperator<T>(skip.Count).Execute(typed).Cast<object>(),

                TakeOperation take => new TakeOperator<T>(take.Count).Execute(typed).Cast<object>(),

                SelectOperation<T> select => new SelectOperator<T>((Func<T, object>)select.Selector.Compile()).Execute(typed),

                _ => throw new NotSupportedException()
            };
        }

        private IOperator<object> CreateOperator(QueryOperation op)
        {
            return op switch
            {
                WhereOperation<T> where =>
                    new WhereOperator<object>(x => where.Predicate.Compile()((T)x)),

                SkipOperation skip =>
                    new SkipOperator<object>(skip.Count),

                TakeOperation take =>
                    new TakeOperator<object>(take.Count),

                SelectOperation<T> select => CreateSelectOperator(select),

                _ => throw new NotSupportedException()
            };
        }

        private IOperator<object> CreateSelectOperator(SelectOperation<T> select)
        {
            var func = (Func<T, object>)select.Selector.Compile();
            return new SelectOperator<object>(x => func((T)x));
        }
    }
}
