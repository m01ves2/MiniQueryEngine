using System.Linq.Expressions;

namespace Day7_translator_v1
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            //Expression<Func<Book, bool>> expr = b => b.Pages > 100;
            //Expression<Func<Book, bool>> expr = b => b.Pages > 100 && b.Pages < 500;
            //Expression<Func<Book, bool>> expr = b => (b.Pages + 2 > 100 && b.Pages < 500) || b.Title == null && b.IsPublished == true && b.Title.Contains('c');
            Expression<Func<Book, bool>> expr = b => b.Title.Contains('c');
            Print(expr);
        }

        private static void Print(Expression expr)
        {
            //var printVisitor = new PrintVisitor();
            //printVisitor.Visit(expr);

            ExpressionTranslator translator = new ExpressionTranslator();
            //translator.Visit(expr);
            string result = translator.Translate(expr);
            Console.WriteLine(result);
        }
    }
}