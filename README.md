Day 1:
- Implemented a simple console calculator using delegates for operation dispatch.
- Refactored architecture into Parser and OperationRegistry for separation of concerns.
- Explored delegates as behavior containers and introduced multicast delegate concept.
Result: 
- foundational understanding of delegates as runtime-bound behavior in C#.
Insight: 
- C# delegates behave as objects encapsulating invocation logic, not as raw function pointers.


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
Result: 
- foundational understanding of AST traversal and Visitor pattern


Day 7:
- Implemented ExpressionTranslator using ExpressionVisitor.
- Added support for binary, unary, conditional, method call, member and constant expressions.
- Improved literal formatting for strings, chars and null.
- Learned how Expression Trees can be translated into another representation.
 Result: 
 - Implemented a basic Expression-to-string translator using ExpressionVisitor.


 Day 8: Query API
- Designed QueryEngine and Query<T>
- Implemented fluent Where() API
- Introduced Expression<Func<T, bool>> storage for deferred filtering
- Built foundation for in-memory query execution layer
Result: 
- Basic query builder infrastructure for future expression-based execution.


Day 9: Execution
- Implemented a pipeline execution model where query operations are collected as a sequence and executed over an IEnumerable<T> source. 
- Introduced core operators (Where, Skip, Take) with support for expression compilation into delegates.
- Explored deferred execution behavior and separation between query definition and execution. 
- Prepared foundation for future query optimization via expression tree merging.
Result: 
- Working pipeline-based query engine with basic query operators and execution model.


Day 10 - Query Optimization (Where Merge + Expression Rewrite)
- Implemented QueryOptimizer that merges consecutive Where operations into a single predicate using Expression Tree rewriting.
- Introduced ExpressionVisitor to correctly replace parameters across merged lambda expressions.
- Fixed pipeline ordering to preserve correct execution of Where, Skip, and Take.
Result: 
- Working query optimizer with correct predicate merging and preserved pipeline order.


Day 11: SELECT & Execution Pipeline
- Extended MiniQueryEngine with SELECT projection support and unified execution pipeline.
- Introduced object-based pipeline execution and expression compilation for projection logic.
- Refactored pipeline to support mixed operations (Where, Skip, Take, Select).
- Improved understanding of execution flow and expression-based transformations.
Result: 
- Working query engine with SELECT projection.

Day 12 - Manual AST Building
- Explored and manually constructed Expression Trees in C#, including binary operations, logical operators, method calls, and closure behavior. 
- Gained understanding of how LINQ expression trees are structured and evaluated at runtime.
Result: 
- practical understanding of Expression Tree internals and ability to manually build and execute lambda expressions.