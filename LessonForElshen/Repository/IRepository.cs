using System.Linq.Expressions;

namespace LessonForElshen.Repository
{
    public interface IRepository<T> where T : class, new()
    {
        IQueryable<T> GetAll();
       
        Task<int> CountAsync();
       

        Task<T?> GetFirstAsync();

        Task<T?> GetFirstAsync(Expression<Func<T, bool>> predicate);
        Task<bool> IsExistAsync(Expression<Func<T, bool>> predicate);
      

        Task AddAsync(T entity);

    }
}
