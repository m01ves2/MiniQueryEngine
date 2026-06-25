using System.Linq.Expressions;

namespace Day6_expression_tree_visitor
{
    class PrintVisitor : MyExpressionVisitor
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
            
            

        protected override void VisitBinary(BinaryExpression node)
        {
            Visit(node.Left);
            Console.Write(Map[node.NodeType]);
            Visit(node.Right);
        }

        protected override void VisitMember(MemberExpression node)
        {
            Visit(node.Expression);
            Console.Write("." + node.Member.Name);
        }

        protected override void VisitConstant(ConstantExpression node)
        {
            Console.Write(node.Value);
        }

        protected override void VisitParameter(ParameterExpression node)
        {
            Console.Write(node.Name);
        }

        protected override void VisitLambda(LambdaExpression node)
        {
            Console.Write("(");
            foreach (var p in node.Parameters) {
                Visit(p);

                if(p != node.Parameters.Last())
                    Console.Write(",");

            }
            Console.Write(")");

            Console.Write(" => ");

            Visit(node.Body);
        }
    }
}
