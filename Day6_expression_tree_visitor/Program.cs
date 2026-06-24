using System.Linq.Expressions;

namespace Day6_expression_tree_visitor
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Expression<Func<Book, bool>> expr = b => b.Pages > 100;
            var result = expr.Compile()(new Book() { Title = "Harry Potter", Pages = 400 });
            Console.Write(result);
        }
    }
}