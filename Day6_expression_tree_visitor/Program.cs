using System.Linq.Expressions;

namespace Day6_expression_tree_visitor
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            //Expression<Func<Book, bool>> expr = b => b.Pages > 100;

            Expression<Func<Book, bool>> expr = b => b.Pages > 100;
            Print(expr);
        }

        private static void Print(Expression expr)
        {
            //// TODO: распознать тип узла
            //// TODO: вызвать Print для детей

            switch (expr) {
                case LambdaExpression l:
                    PrintLambda(l);
                    break;

                case ParameterExpression p:
                    PrintParam(p);
                    break;

                case BinaryExpression b:
                    PrintBinary(b);
                    break;

                case UnaryExpression u:
                    PrintUnary(u);
                    break;

                case ConstantExpression c:
                    PrintConstant(c);
                    break;

                case MemberExpression m:
                    PrintMember(m);
                    break;

                case MethodCallExpression mce:
                    PrintMethodCall(mce);
                    break;

                default:
                    throw new NotSupportedException(expr.GetType().Name);
            }
        }

        private static void PrintLambda(LambdaExpression lambda)
        {
            Console.WriteLine("(");
            foreach (var lambdaParameter in lambda.Parameters) {
                Print(lambdaParameter);

                if(lambda.Parameters.Last() != lambdaParameter)
                    Console.WriteLine(",");
            }
            Console.WriteLine(")");

            Console.WriteLine("=>");

            Print(lambda.Body);
        }

        private static void PrintParam(ParameterExpression param)
        {
            Console.WriteLine(param.Name);
        }

        private static void PrintBinary(BinaryExpression bin)
        {
            Print(bin.Left);
            switch (bin.NodeType) {
                case ExpressionType.GreaterThan:
                    Console.WriteLine(">");
                    break;
                case ExpressionType.Equal:
                    Console.WriteLine("=");
                    break;
                case ExpressionType.LessThan:
                    Console.WriteLine("<");
                    break;
                case ExpressionType.GreaterThanOrEqual:
                    Console.WriteLine(">=");
                    break;
                case ExpressionType.LessThanOrEqual:
                    Console.WriteLine("<=");
                    break;
                case ExpressionType.Add:
                    Console.WriteLine("+");
                    break;
                case ExpressionType.Subtract:
                    Console.WriteLine("-");
                    break;
                case ExpressionType.Multiply:
                    Console.WriteLine("*");
                    break;
                case ExpressionType.Divide:
                    Console.WriteLine("/");
                    break;
                case ExpressionType.Modulo:
                    Console.WriteLine("%");
                    break;
                case ExpressionType.LeftShift:
                    Console.WriteLine("<<");
                    break;
                case ExpressionType.RightShift:
                    Console.WriteLine(">>");
                    break;
                case ExpressionType.And:
                    Console.WriteLine("&");
                    break;
                case ExpressionType.Or:
                    Console.WriteLine("|");
                    break;
                case ExpressionType.Assign:
                    Console.WriteLine("=");
                    break;
                case ExpressionType.AndAlso:
                    Console.WriteLine("&&");
                    break;
                case ExpressionType.OrElse:
                    Console.WriteLine("||");
                    break;
                default:
                    throw new ArgumentException("Unknown argument: " + bin.NodeType);
            }
            Print(bin.Right);
        }

        private static void PrintUnary(UnaryExpression unary)
        {

            switch (unary.NodeType) {

                case ExpressionType.PostIncrementAssign:
                    Print(unary.Operand);
                    Console.WriteLine("++");
                    break;
                case ExpressionType.PostDecrementAssign:
                    Print(unary.Operand);
                    Console.WriteLine("--");
                    break;

                case ExpressionType.PreIncrementAssign:
                    Console.WriteLine("++");
                    Print(unary.Operand);
                    break;
                case ExpressionType.PreDecrementAssign:
                    Console.WriteLine("--");
                    Print(unary.Operand);
                    break;

                default:
                    throw new ArgumentException("Unknown argument: " + unary.NodeType);
            }
        }

        private static void PrintConstant(ConstantExpression constant)
        {
            Console.WriteLine(constant.Value);
        }

        private static void PrintMember(MemberExpression member)
        {
            Print(member.Expression);
            Console.WriteLine('.');
            Console.WriteLine(member.Member.Name);
        }

        private static void PrintMethodCall(MethodCallExpression mce)
        {
            Print(mce.Object);   // p.Name
            foreach (var arg in mce.Arguments)
                Print(arg);       // "A"
        }
    }
}