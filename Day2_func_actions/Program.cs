namespace Day2_func_actions
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            List<int> numbers = new() { 1, 2, 3, 4, 5 };
            Action<int> action = SquareAction;
            Func<int, int> func = SquareFunc;
            Method(numbers, action);

            Console.WriteLine();

            var resultFunc = Method2(numbers, func);
            resultFunc.ForEach(x => Console.Write(x + " "));
            
        }

        private static void Method(List<int> num, Action<int> action)
        {
            for (int i = 0; i < num.Count; i++) {
                action(num[i]);
            }
        }

        public static void SquareAction(int i)
        {
            Print(i * i);
        }

        public static void Print(int num)
        {
            Console.Write(num + " ");
        }

        private static List<int> Method2(List<int> num, Func<int, int> func)
        {
            List<int> result = new();
            for (int i = 0; i < num.Count; i++) {
                result.Add(func(num[i]));
            }
            return result;
        }

        public static int SquareFunc(int i)
        {
            return i * i;
        }
    }
}