using DayX_query_merge_optimizer.Operators;

namespace DayX_query_merge_optimizer
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

            var query = engine.Query<Book>().Where(b => b.Pages > 100).Where(c => c.Pages < 500).Skip(1).Take(3).Execute(books);

            var result = engine.Query<Book>().Where(b => b.Pages > 100).Where(c => c.Pages < 500).Skip(1).Take(3).Execute(books).CountResult();
        }
    }
}