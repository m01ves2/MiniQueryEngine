namespace Day2_func_actions
{
    public static class ListExtensions
    {
        public static List<T> Where<T>(this List<T> numbers, Func<T, bool> predicate)
        {
            List<T> result = new();
            foreach (T num in numbers) {
                if (predicate(num))
                    result.Add(num);
            }

            return result;
        }
    }
}
