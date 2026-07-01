using System.Linq.Expressions;

namespace DayXII_manual_AST_building
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            //Exercise1();
            //Exercise2();
            //Exercise3();
            //Exercise4();
            Exercise5();
        }


        private static void Exercise1()
        {
            //задача: построить вручную дерево b => b.Pages > 100
            //Expression<Func<Book, bool>> expression = b => b.Pages > 100;

            var param = Expression.Parameter(typeof(Book), "b");
            var left = Expression.Property(param, nameof(Book.Pages)); //Expression.Property(param, "Pages")
            var right = Expression.Constant(100);
            var body = Expression.GreaterThan(left, right);
            var lambda = Expression.Lambda<Func<Book, bool>>(body, param);

            Expression<Func<Book, bool>> expr = lambda;
            var compiled = lambda.Compile();

            Console.WriteLine(lambda.ToString());
            Console.WriteLine(compiled(new Book { Pages = 50 }));  // False
            Console.WriteLine(compiled(new Book { Pages = 150 })); // True
        }

        private static void Exercise2()
        {
            //задача: построить вручную дерево b => b.Pages > 100 && b.Pages < 500

            //Expression<Func<Book, bool>> expression = b => b.Pages > 100 && b.Pages < 500;
            var param = Expression.Parameter(typeof(Book), "b");
            var pagesAccess = Expression.Property(param, nameof(Book.Pages));

            var leftleft = pagesAccess;
            var leftright = Expression.Constant(100);
            var left = Expression.GreaterThan(pagesAccess, leftright);


            var rightleft = pagesAccess;
            var rightright = Expression.Constant(500);
            var right = Expression.LessThan(rightleft, rightright);

            var body = Expression.AndAlso(left, right);
            var lambda = Expression.Lambda<Func<Book, bool>>(body, param);

            Expression<Func<Book, bool>> expr = lambda;
            var compiled = lambda.Compile();

            Console.WriteLine(lambda.ToString());
            Console.WriteLine(compiled(new Book { Pages = 50 }));  // False
            Console.WriteLine(compiled(new Book { Pages = 150 })); // True
        }
        private static void Exercise3()
        {
            //задача: построить b => b.Title == "CLR via C#"

            //Expression<Func<Book, bool>> expression = b => b.Title == "CLR via C";

            var param = Expression.Parameter(typeof(Book), "b");
            var left = Expression.Property(param, nameof(Book.Title));
            var right = Expression.Constant("CLR via C");
            var body = Expression.Equal(left, right);

            var lambda = Expression.Lambda<Func<Book, bool>>(body, param);

            Expression<Func<Book, bool>> expr = lambda;
            var compiled = lambda.Compile();

            Console.WriteLine(lambda.ToString());
            Console.WriteLine(compiled(new Book { Title = "DDD" }));  // False
            Console.WriteLine(compiled(new Book { Title = "CLR via C" })); // True


            //задача 2: 
            //C# компилятор сделал вот это: заменить "CLR via C" на переменную title с этим значением.
            //Посмотреть, перестроилось ли дерево.
            var title = "CLR via C#";
            Expression<Func<Book, bool>> expression2 = b => b.Title == title;

            //в результате скомпилировался класс:
            //class <>c__DisplayClass
            //{
            //    public string title;
            //}

            //И переписал выражение примерно так:
            //b => b.Title == this.title
            //итого, title стал MemberExpression
        }
        private static void Exercise4()
        {
            //задача: построить вручную дерево b => b.Title.StartsWith("C")
            //Expression<Func<Book, bool>> expression = b => b.Title.StartsWith("C");

            //низкоуровневый код. Высокоуровневый в Exercise5
            var param = Expression.Parameter(typeof(Book), "b");
            var title = Expression.Property(param, nameof(Book.Title));
            var arg = Expression.Constant("C");
            var method = typeof(string).GetMethod(
                nameof(string.StartsWith),
                new[] { typeof(string) }
            );

            var body = Expression.Call(title, method, arg);
            var lambda = Expression.Lambda<Func<Book, bool>>(body, param);

            Console.WriteLine(lambda);
            Console.WriteLine(lambda.Compile()(new Book { Title = "CLR via C#" }));
            Console.WriteLine(lambda.Compile()(new Book { Title = "DDD" }));
        }

        private static void Exercise5()
        {
            //задача: построить вручную дерево b => b.Title.StartsWith("C")
            //Expression<Func<Book, bool>> expression = b => b.Title.StartsWith("C");

            //Высокоуровневый код. Низкоуровневый в Exercise4

            var param = Expression.Parameter(typeof(Book), "b");
            var title = Expression.Property(param, nameof(Book.Title));
            var arg = Expression.Constant("C");

            var method = typeof(string).GetMethod(nameof(string.StartsWith), new[] { typeof(string) });
            var body =  Expression.Call(title, method, arg);

            var lambda = Expression.Lambda<Func<Book, bool>>(body, param);

            var compiled = lambda.Compile();

            Console.WriteLine(lambda);
            Console.WriteLine(compiled(new Book { Title = "CLR via C#" })); // True
            Console.WriteLine(compiled(new Book { Title = "DDD" }));        // False
        }
    }
}
