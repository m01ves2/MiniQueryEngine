using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Day7_translator_v1
{
    public class ExpressionTranslator : ExpressionVisitor
    {
        private readonly Dictionary<ExpressionType, string> Map = new()
        {
            { ExpressionType.GreaterThan, ">" },
            { ExpressionType.GreaterThanOrEqual, ">="},
            { ExpressionType.LessThan, "<"},
            { ExpressionType.LessThanOrEqual, "<="},
            { ExpressionType.Equal, "=="},
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
        private StringBuilder _sb  = new StringBuilder();
        protected override Expression VisitBinary(BinaryExpression node)
        {
            Visit(node.Left);
            _sb.Append(Map[node.NodeType]);
            Visit(node.Right);

            return node;
        }

        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            _sb.Append("(");
            foreach (var p in node.Parameters) {
                Visit(p);

                if (p != node.Parameters.Last())
                    _sb.Append(",");

            }
            _sb.Append(")");

            _sb.Append(" => ");

            Visit(node.Body);

            return node;
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            _sb.Append(node.Value);

            return base.VisitConstant(node);
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            Visit(node.Expression);
            _sb.Append("." + node.Member.Name);

            return node;
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            _sb.Append(node.Name);

            return base.VisitParameter(node);
        }

        public string Translate(Expression expr)
        {
            _sb.Clear();

            Visit(expr);
            return _sb.ToString();
        }
    }
}
