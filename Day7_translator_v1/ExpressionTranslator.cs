using System.Linq.Expressions;
using System.Text;

namespace Day7_translator_v1
{
    public class ExpressionTranslator : ExpressionVisitor
    {
        private readonly static Dictionary<ExpressionType, string> Map = new()
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
        private readonly StringBuilder _sb  = new StringBuilder();
        protected override Expression VisitBinary(BinaryExpression node)
        {
            _sb.Append("(");

            Visit(node.Left);
            
            _sb.Append(Map[node.NodeType]);
            
            Visit(node.Right);
            
            _sb.Append(")");

            return node;
        }

        protected override Expression VisitUnary(UnaryExpression node)
        {
            switch(node.NodeType) {
                case ExpressionType.PostIncrementAssign:
                    Visit(node.Operand);
                    _sb.Append("++");
                    break;
                case ExpressionType.PostDecrementAssign:
                    Visit(node.Operand);
                    _sb.Append("--");
                    break;
                case ExpressionType.PreIncrementAssign:
                    _sb.Append("++");
                    Visit(node.Operand);
                    break;
                case ExpressionType.PreDecrementAssign:
                    _sb.Append("--");
                    Visit(node.Operand);
                    break;

                case ExpressionType.UnaryPlus:
                    _sb.Append('+');
                    Visit(node.Operand);
                    break;
                case ExpressionType.Negate:
                    _sb.Append("(");
                    _sb.Append("-");
                    Visit(node.Operand);
                    _sb.Append(")");
                    break;

                case ExpressionType.Not:
                    _sb.Append("!");
                    Visit(node.Operand);
                    break;
                case ExpressionType.OnesComplement:
                    _sb.Append("~");
                    Visit(node.Operand);
                    break;

                default:
                    _sb.Append(node.NodeType);
                    Visit(node.Operand);
                    break;

            }

            return node;
        }

        protected override Expression VisitConditional(ConditionalExpression node)
        {
            Visit(node.Test);

            _sb.Append('?');
            
            Visit(node.IfTrue);
            
            _sb.Append(':');
            
            Visit(node.IfFalse);

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
            switch(node.Value) {
                case string str:
                    _sb.Append("\"");
                    _sb.Append(str);
                    _sb.Append("\"");
                    break;

                case char c:
                    _sb.Append("'");
                    _sb.Append(c);
                    _sb.Append("'");
                    break;

                case null:
                    _sb.Append("null");
                    break;

                default: _sb.Append(node.Value);
                    break;
            }

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

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node.Object != null) {
                Visit(node.Object);
                _sb.Append('.');
            }

            _sb.Append(node.Method.Name);
            _sb.Append("(");


            foreach (var arg in node.Arguments) {               
                Visit(arg);

                if(arg != node.Arguments.Last())
                    _sb.Append(", ");
            }

            _sb.Append(")");

            return node;
        }
        public string Translate(Expression expr)
        {
            _sb.Clear();

            Visit(expr);
            return _sb.ToString();
        }
    }
}
