using System.Linq.Expressions;

namespace Day5_expressions
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Expression<Func<Book, bool>> expr = b => b.Pages > 100;

            Console.WriteLine("Expression: ");
            Console.WriteLine(expr);
            Console.WriteLine(expr.Body);
            Console.WriteLine(expr.Body.NodeType);
            Console.WriteLine(expr.Body.GetType());

            Console.WriteLine("Expression body: ");
            var body = (BinaryExpression)expr.Body;
            var left = (MemberExpression)body.Left;
            var right = (ConstantExpression)body.Right;

            Console.WriteLine("Expression body left: ");
            Console.WriteLine(body.Left);
            Console.WriteLine("Expression body left type: ");
            Console.WriteLine(body.Left.GetType().Name);

            Console.WriteLine("Expression body right: ");
            Console.WriteLine(body.Right);
            Console.WriteLine("Expression body right type: ");
            Console.WriteLine(body.Right.GetType().Name);

            Console.WriteLine(left.Member.GetType().Name); //RuntimePropertyInfo
        }
    }
}