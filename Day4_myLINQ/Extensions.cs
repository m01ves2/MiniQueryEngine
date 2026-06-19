namespace Day4_myLINQ
{
    public static class Extensions
    {
        public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> values, Func<T, bool> predicate)
        {

            foreach (var item in values) {
                
                if (predicate(item))
                    yield return item;
            }
        }
    }
}
