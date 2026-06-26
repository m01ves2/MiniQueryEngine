using System.Linq.Expressions;

namespace Day6_expression_tree_visitor
{
    public class MyPrintVisitor : ExpressionVisitor
    {
        private readonly Dictionary<ExpressionType, string> Map = new()
        {
            { ExpressionType.GreaterThan, ">" },
            { ExpressionType.Equal, "="},
            { ExpressionType.GreaterThanOrEqual, ">="},
            { ExpressionType.LessThan, "<"},
            { ExpressionType.LessThanOrEqual, "<="},
            { ExpressionType.Add, "+"},
            { ExpressionType.Subtract, "-"},
            { ExpressionType.Multiply, "*"},
            { ExpressionType.Divide, "/"},
            { ExpressionType.Modulo, "%"},
            { ExpressionType.LeftShift, "<<"},
            { ExpressionType.RightShift, ">>"},
            { ExpressionType.And, "&"},
            { ExpressionType.Or, "|"},
            { ExpressionType.Assign, "="},
            { ExpressionType.AndAlso, "&&"},
            { ExpressionType.OrElse, "||"},
        };

        protected override Expression VisitBinary(BinaryExpression node)
        {
            Visit(node.Left);
            Console.Write(Map[node.NodeType]);
            Visit(node.Right);

            return node;
        }

        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            Console.Write("(");
            foreach (var p in node.Parameters) {
                Visit(p);

                if (p != node.Parameters.Last())
                    Console.Write(",");

            }
            Console.Write(")");

            Console.Write(" => ");

            Visit(node.Body);

            return node;
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            Console.Write(node.Value);

            return base.VisitConstant(node);
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            Visit(node.Expression);
            Console.Write("." + node.Member.Name);

            return node;
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            Console.Write(node.Name);

            return base.VisitParameter(node);
        }
    }
}
