namespace Day3_lambda
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Func<int, bool> check = IsGreaterThan10;
            Func<int, bool> check2 = x => x > 10;
            bool result = check2(15);

            Console.WriteLine(result);
        }

        static bool IsGreaterThan10(int number)
        {
            return number > 10;
        }
    }
}