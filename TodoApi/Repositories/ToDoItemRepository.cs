using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Models;

namespace TodoApi.Repositories
{
    public class ToDoItemRepository<T> : IRepository<T> where T : class
    {
        private readonly ToDoDbContext _context;
        public ToDoItemRepository(ToDoDbContext context)
        {
            _context = context;
        }

        public async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }


        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> Create(T entity)
        {
            await _context.AddAsync(entity);
            return entity;
        }
        public async Task<bool> Exists(Guid id)
        {
            var entity = await GetById(id);
            return entity != null;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<T> GetAllAsQueryable()
        {
            return _context.Set<T>().AsQueryable();
        }
    }
}
