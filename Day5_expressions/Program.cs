using System.Linq.Expressions;

namespace Day5_expressions
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Expression<Func<Book, bool>> expr = b => b.Pages > 100;

            var lambda = expr;
            var lambdaExpr = (LambdaExpression)lambda ?? throw new ArgumentNullException(nameof(lambda));
            Print(lambdaExpr);

            var lambdaParam = lambdaExpr.Parameters.Single();
            var lambdaParamExpr = (ParameterExpression)lambdaParam ?? throw new ArgumentNullException(nameof(lambdaParam));
            Print(lambdaParamExpr);

            var body = lambdaExpr.Body;
            var bodyExpr = (BinaryExpression)body ?? throw new ArgumentNullException(nameof(body));
            Print(bodyExpr);

            var leftBody = bodyExpr.Left;
            var leftBodyExpr = (MemberExpression)leftBody ?? throw new ArgumentNullException(nameof(leftBody));
            Print(leftBodyExpr);

            var rightBody = bodyExpr.Right;
            var rightBodyExpr = (ConstantExpression)rightBody ?? throw new ArgumentNullException(nameof(rightBody));
            Print(rightBodyExpr);
        }

        private static void Print(Expression? expr)
        {
            Console.WriteLine($"NodeType: {expr?.NodeType}");
            Console.WriteLine($"Type    : {expr?.Type}");
            Console.WriteLine($"CLR Type: {expr?.GetType()}");
            Console.WriteLine("============================");
        }
    }
}