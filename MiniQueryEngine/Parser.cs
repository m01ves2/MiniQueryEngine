namespace MiniQueryEngine
{
    public static class Parser
    {
        public static (int num1, int num2, char op) ParseExpression(string expr)
        {
            if (string.IsNullOrWhiteSpace(expr))
                throw new InvalidOperationException("Empty input");

            var parts = expr.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 3)
                throw new InvalidOperationException("Format: num1 num2 op");

            int num1 = int.Parse(parts[0]);
            int num2 = int.Parse(parts[1]);
            char op = parts[2][0];

            return (num1, num2, op);
        }
    }
}
