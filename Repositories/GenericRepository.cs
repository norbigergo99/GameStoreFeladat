using GameStoreBeGNorbi.Context;
using GameStoreBeGNorbi.Contracts;
using Microsoft.EntityFrameworkCore;

namespace GameStoreBeGNorbi.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly GameStoreContext _context;
        public GenericRepository(GameStoreContext context)
        {
            _context = context;
        }
        public virtual async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public virtual async Task<List<T>> GetAll() => await _context.Set<T>().ToListAsync();
        public virtual async Task<T?> GetById(int id) => await _context.Set<T>().FindAsync(id);
        public async Task Update(T changes)
        {
            _context.Update(changes);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null) { return; }
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
