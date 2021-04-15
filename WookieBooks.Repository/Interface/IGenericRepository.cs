using System.Collections.Generic;
using System.Threading.Tasks;

namespace WookieBooks.Repository
{
    /// <summary>
    /// Generic repository to use as base for having multiple type of repositories
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Add(T entity);
        Task<T> Delete(int id);
        Task<T> Update(T entity);
    }
}
