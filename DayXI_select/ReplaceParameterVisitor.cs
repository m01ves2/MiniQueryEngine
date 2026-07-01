using System.Linq.Expressions;

namespace DayXI_select
{
    public class ReplaceParameterVisitor : ExpressionVisitor
    {
        private ParameterExpression newParameter;
        private ParameterExpression oldParameter;

        public ReplaceParameterVisitor(ParameterExpression newParameterExpression, ParameterExpression oldParameterExpression)
        {
            this.newParameter = newParameterExpression;
            this.oldParameter = oldParameterExpression;
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            if(oldParameter == node)
                return newParameter;
            
            return node;
        }
    }
}
