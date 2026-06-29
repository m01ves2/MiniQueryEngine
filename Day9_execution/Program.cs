using System.Linq.Expressions;

namespace Day9_execution
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            List<Book> books = new List<Book>()
            {
                new Book(){Title = "title100", Pages = 100},
                new Book(){Title = "title200", Pages = 200},
                new Book(){Title = "title300", Pages = 300},
                new Book(){Title = "title400", Pages = 400},
                new Book(){Title = "title500", Pages = 500},
            };

            var engine = new QueryEngine();

            var result = engine.Query<Book>().Where(b => b.Pages > 100).Skip(1).Take(3).Execute(books);
        }
    }
}