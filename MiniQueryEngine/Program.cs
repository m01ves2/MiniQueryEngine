namespace MiniQueryEngine
{
    public class Program
    {
        delegate int Operation(int a, int b);

        public static void Main(string[] args)
        {
            Dictionary<char, Operation> ops = new Dictionary<char, Operation>()
            {
                { '+', Add },
                { '-', Subtract },
                { '*', Multiply },
                { '/', Divide },
            };

            while (true) {
                Console.WriteLine("Input number1, number2, operation: ");
                string? expr = Console.ReadLine();

                if (expr == "q" || expr == "exit")
                    break;

                try {
                    (int num1, int num2, char op) = ParseExpression(expr, ops.Keys.ToArray());
                    
                    var res = ops[op](num1, num2);
                    Console.WriteLine($"Result: {res}");
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static int Add(int a, int b)
        {
            return a + b;
        }

        private static int Subtract(int a, int b)
        {
            return a - b;
        }

        private static int Multiply(int a, int b)
        {
            return a * b;
        }

        private static int Divide(int a, int b)
        {
            return a / b;
        }

        private static (int num1, int num2, char op) ParseExpression(string? expr, char[] ops)
        {
            if (expr == null)
                throw new InvalidOperationException("No input");

            expr = expr.Trim();
            string[] str = expr.Split(' ', 3, StringSplitOptions.RemoveEmptyEntries);

            if (str.Length != 3)
                throw new InvalidOperationException("Not enough identifiers");

            int num1 = int.Parse(str[0]);
            int num2 = int.Parse(str[1]);

            if (str[2].Length > 1)
                throw new InvalidOperationException($"Not an operator: {str[2]}");

            char op = char.Parse(str[2]);

            if(!ops.Contains(op))
                throw new InvalidOperationException($"Wrong operator: {str[2]}");

            return (num1, num2, op);
        }
    }
}