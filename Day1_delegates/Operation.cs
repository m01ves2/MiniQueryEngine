namespace Day1_delegates
{
    public delegate int Operation(int a, int b);

    public delegate void OperationExecutedHandler(int left, int right, char operation, int result);
}
