namespace MiniQueryEngine
{
    public class Program
    {
        public static void Main()
        {
            OperationExecutedHandler handlers = Logger.ConsoleLogger;
            handlers += Logger.StatisticsLogger;

            while (true) {
                Console.WriteLine("Input: num1 num2 op (or 'q' for quit): ");
                var input = Console.ReadLine() ?? "";

                if (input == "q" || input == "exit")
                    break;

                try {
                    var (num1, num2, op) = Parser.ParseExpression(input);

                    if (!OperationRegistry.TryGet(op, out var operation))
                        throw new InvalidOperationException($"Unknown operator: {op}");

                    var result = operation(num1, num2);

                    handlers(num1, num2, op, result);
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}