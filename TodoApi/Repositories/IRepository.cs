using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace TodoApi.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> GetAllAsQueryable();
        Task<T> GetById(Guid id);
        Task<T> Create(T entity);
        Task<bool> Exists(Guid id);
        Task Update(T entity);
        Task Delete(T entity);
        Task Save();
    }
}
