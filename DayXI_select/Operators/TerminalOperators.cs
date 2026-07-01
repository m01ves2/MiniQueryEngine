namespace DayXI_select.Operators
{
    public static class TerminalOperators
    {
        public static int CountResult<T>(this IEnumerable<T> source)
        {
            int c = 0;

            foreach (var _ in source)
                c++;

            return c;
        }

        public static bool AnyResult<T>(this IEnumerable<T> source)
        {
            foreach (var _ in source)
                return true;

            return false;
        }

        public static T FirstResult<T>(this IEnumerable<T> source)
        {
            foreach (var item in source)
                return item;

            throw new InvalidOperationException();
        }
    }
}
