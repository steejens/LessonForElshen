using System.Linq.Expressions;

namespace LessonForElshen.Extensions
{
    public static class PredicateBuilderExtensions
    {
        public static Expression<Func<T, bool>> AndAlso<T>(
            this Expression<Func<T, bool>> expr1,
            Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters);
            var combinedExpr = Expression.Lambda<Func<T, bool>>(
                Expression.AndAlso(expr1.Body, invokedExpr),
                expr1.Parameters);

            return combinedExpr;
        }
    }
}
