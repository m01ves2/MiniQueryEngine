namespace Day1_delegates
{
    public static class Logger
    {
        public static void ConsoleLogger(int left, int right, char operation, int result)
        {
            Console.WriteLine($"{left} {operation} {right} = {result} ");
        }

        public static void StatisticsLogger(int left, int right, char operation, int result)
        {
            Console.WriteLine($"Statistics updated");
        }
    }
}
