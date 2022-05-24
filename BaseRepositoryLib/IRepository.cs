using System.Linq.Expressions;

namespace BaseRepositoryLib
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        IQueryable<T> Get(Expression<Func<T, bool>> expression);
    }
}