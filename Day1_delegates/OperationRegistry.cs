namespace Day1_delegates
{
    public static class OperationRegistry
    {
        private static readonly Dictionary<char, Operation> _operations =
            new()
            {
                ['+'] = CalculatorOperations.Add,
                ['-'] = CalculatorOperations.Subtract,
                ['*'] = CalculatorOperations.Multiply,
                ['/'] = CalculatorOperations.Divide
            };
        public static bool TryGet(char op, out Operation operation) => _operations.TryGetValue(op, out operation);

    }
}
