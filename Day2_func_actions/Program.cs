namespace Day2_func_actions
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            List<int> numbers = new() { 1, 2, 3, 4, 5 };
            Func<int, bool> predicate = IsEven;

            List<int> result = Where(numbers, predicate);

            for (int i = 0; i < result.Count; i++) {
                Console.WriteLine(result[i]);
            }
        }


        private static List<int> Where(List<int> numbers, Func<int, bool> predicate)
        {
            List<int> result = new();
            foreach (int num in numbers) {
                if (predicate(num))
                    result.Add(num);
            }

            return result;
        }

        private static bool IsEven(int x) {
            return x % 2 == 0;
        }
    }
}