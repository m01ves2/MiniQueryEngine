namespace Day4_myLINQ
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            List<int> list = new List<int>() {1, 10, 15, 12, 3, 2 };
            var result = list.MyWhere(x => x >= 10 ).MyToList();

            Console.WriteLine("first element: " + result.MyFirst());

            Console.WriteLine("All elements: ");
            var resultStrings = result.MySelect(x => x.ToString());
            foreach (var resultString in resultStrings) {
                Console.WriteLine(resultString);
            }
        }
    }
}