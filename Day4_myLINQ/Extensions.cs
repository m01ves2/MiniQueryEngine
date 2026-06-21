using System.Collections.Specialized;
using System.Diagnostics;

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

        public static IEnumerable<S> MySelect<T, S>(this IEnumerable<T> values, Func<T, S> selector)
        {
            foreach(var item in values) {
               yield return selector(item);
            }
        }

        public static bool MyAny<T>(this IEnumerable<T> value, Func<T, bool> predicate)
        {
            foreach(var item in value) {
                if (predicate(item))
                    return true;
            }
            return false;
        }

        public static T? MyFirst<T>(this IEnumerable<T> values)
        {
            foreach (var item in values) {
                return item;
            }
            return default(T);
        }

        public static int MyCount<T>(this IEnumerable<T> values)
        {
            int count = 0;
            foreach (var item in values) {
                count++;
            }
            return count;
        }

        public static List<T> MyToList<T>(this IEnumerable<T> values)
        {
            List<T> list = new List<T>();
            foreach (var item in values) {
                list.Add(item);
            }
            return list;
        }
    }
}
