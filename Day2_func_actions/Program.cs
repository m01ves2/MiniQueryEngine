using System.Numerics;

namespace Day2_func_actions
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            List<int> numbers = new() { 1, 2, 3, 4, 5 };
            Func<int, bool> predicate = IsEven;
            List<int> result = numbers.Where<int>(predicate);
            Print(result);

            Console.WriteLine();

            List<string> strings = new() { "She", "sells", "seashells", "by", "the", "seashore" };
            Func<string, bool> strPredicate = LongString;
            List<string> stringsResult = strings.Where<string>(strPredicate);
            Print(stringsResult);

        }

        private static bool IsEven(int x) {
            return x % 2 == 0;
        }

        private static bool LongString(string str)
        {
            return str.Length > 3;
        }

        private static void Print<T>(List<T> values)
        {
            for (int i = 0; i < values.Count; i++) {
                Console.Write(values[i] + " ");
            }
        }
    }
}