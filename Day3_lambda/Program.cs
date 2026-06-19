namespace Day3_lambda
{
    public static class Program
    {
        static void Main()
        {
            List<int> numbers = [1, 5, 12, 20, 7, 15];

            var result = numbers.Where(x =>
            {
                Console.WriteLine($"Check {x}");
                return x > 10;
            });

            Console.WriteLine("Where finished");

            foreach (var item in result) {
                Console.WriteLine($"Result {item}");
            }
        }
    }
}