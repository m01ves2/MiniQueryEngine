Day 1:
- Implemented a simple console calculator using delegates for operation dispatch.
- Refactored architecture into Parser and OperationRegistry for separation of concerns.
- Explored delegates as behavior containers and introduced multicast delegate concept.
Result: foundational understanding of delegates as runtime-bound behavior in C#.
Insight: C# delegates behave as objects encapsulating invocation logic, not as raw function pointers.


Day 2:
- Learned Func<T, TResult> and Action<T> delegates
- Implemented custom Where<T> method with Func<T, bool> predicate
- Extended List<T> using extension methods syntax
Result:
- Learned Func/Action delegates; applied them in generic extension methods (Where<T>)


Day 3:
- Learned lambda expressions and how they compile into delegates
- Investigated how lambdas are represented in compiled code (using ILSpy)
- Explored internal behavior of Enumerable.Where<TSource> and the concept of deferred execution
- Observed how predicates (Func<T, bool>) are passed into LINQ operators
Result:
- Understood that lambda expressions are not "magic syntax", but a way to create delegates
- Gained initial understanding of LINQ as a deferred execution pipeline built on IEnumerable<T> and Func delegates


Day 4:
- Implemented LINQ-like MyWhere, MySelect, MyAny, MyFirst, MyCount, MyToList
- Introduced deferred execution using yield return
- Explored IEnumerable<T> and IEnumerator<T> behavior
- Observed lazy evaluation and pipeline execution in LINQ-like chains
Result:
- Built a minimal LINQ-like pipeline with both lazy (Where, Select) and terminal (Any, First, Count, ToList) operators
- Understood that IEnumerable<T> represents a deferred execution sequence, not a computed collection


Day 5:
- Explored Expression Tree structure in C#
- Inspected Expression<Func<T, bool>> using debugger (NodeType, Type, GetType)
- Manually decomposed simple lambda expression into:
  LambdaExpression -> BinaryExpression -> MemberExpression / ConstantExpression
- Practiced type casting of Expression nodes (Lambda, Binary, Member, Constant)
Result:
- Clear understanding that Expression Trees represent code as data (AST-like structure)
- Ability to manually read and decompose simple expression trees


Day 6:
- implemented manual expression tree traversal
- replaced switch-based dispatch with custom visitor
- migrated to ExpressionVisitor
- implemented PrintVisitor for formatting expressions
Result: foundational understanding of AST traversal and Visitor pattern