namespace Day8_API
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            QueryEngine engine = new QueryEngine();
            engine.Query<Book>().Where(b => b.Pages > 200);
        }
    }
}