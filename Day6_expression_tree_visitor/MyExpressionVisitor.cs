using System.Linq.Expressions;
using System.Reflection.Metadata;

namespace Day6_expression_tree_visitor
{
    abstract class MyExpressionVisitor
    {
        public void Visit(Expression expr)
        {
            switch (expr) {
                case BinaryExpression b:
                    VisitBinary(b);
                    break;

                case MemberExpression m:
                    VisitMember(m);
                    break;

                case ConstantExpression c:
                    VisitConstant(c);
                    break;

                case ParameterExpression p:
                    VisitParameter(p);
                    break;

                case LambdaExpression l:
                    VisitLambda(l);
                    break;

                default:
                    throw new NotSupportedException(expr.GetType().Name);
            }
        }

        protected abstract void VisitBinary(BinaryExpression node);
        protected abstract void VisitMember(MemberExpression node);
        protected abstract void VisitConstant(ConstantExpression node);
        protected abstract void VisitParameter(ParameterExpression node);
        protected abstract void VisitLambda(LambdaExpression node);
    }
}
