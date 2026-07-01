using System.Linq.Expressions;
using DayXI_select.QueryOperations;

namespace DayXI_select
{
    public class QueryOptimizer<T>
    {
        //0.создать новый список операций.Создать переменную left = null
        //1.пройти в цикле весь старый список слева направо.i = 0....N
        //2.1 берем следующий элемент op = old[i]
        //2.2 если op.type != where => записать op в новый список.  Если left != null => записываем left в новый список. left = null;
        //2.3 иначе, если op.type == where && left != null => left = merge(left, op)
        //2.4 иначе, если op.type == where && left == null => left = op
        //3.повторить 2.1
        //4.если left != null => записать в новый список
        public IReadOnlyList<QueryOperation> Optimize(IReadOnlyList<QueryOperation> ops)
        {

            List<QueryOperation> newOps = new List<QueryOperation>();
            WhereOperation<T>? left = null;

            foreach (var op in ops) {
                if (op is WhereOperation<T> where) {
                    if (left != null)
                        left = Merge(left, where);
                    else
                        left = where;
                }
                else {
                    if (left != null) {
                        newOps.Add(left);
                        left = null;
                    }
                    newOps.Add(op);
                }
            }

            if (left != null)
                newOps.Add(left);
            return newOps;
        }

        public WhereOperation<T> Merge(WhereOperation<T> left, WhereOperation<T> right)
        {
            var leftParameter = left.Predicate.Parameters[0];
            var leftBody = left.Predicate.Body;

            var rightParameter = right.Predicate.Parameters[0];
            var rightBody = right.Predicate.Body;

            var visitor = new ReplaceParameterVisitor(leftParameter, rightParameter);

            var fixedRightBody = visitor.Visit(rightBody);

            var mergedBody = Expression.AndAlso(leftBody, fixedRightBody);

            var lambda = Expression.Lambda<Func<T, bool>>(mergedBody, leftParameter);

            return new WhereOperation<T>(lambda);
        }
    }
}
