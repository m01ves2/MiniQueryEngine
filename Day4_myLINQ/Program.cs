namespace Day4_myLINQ
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            List<int> list = new List<int>() {1, 10, 15, 12, 3, 2 };
            var result = list.MyWhere(x => x >= 10 );

            Console.WriteLine("result: " + result.First() );

            foreach (var item in result) {
                Console.WriteLine(item);
            }
        }
    }
}