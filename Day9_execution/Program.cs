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

            QueryEngine engine = new QueryEngine();
            var filteredBooks = engine.Query<Book>().Where(b => b.Pages > 200).Execute(books);

            Console.WriteLine("Before foreach");

            foreach (var b in filteredBooks) {
                Console.WriteLine(b.Title);
            }
        }
    }
}