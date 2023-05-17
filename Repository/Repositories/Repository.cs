using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> entities;

        public Repository(AppDbContext context)
        {
            _context = context;
            entities = _context.Set<T>();
        }

        public async Task CreateAsync(T entity)
        {
            if(entity == null) {  throw new ArgumentNullException(nameof(entity)); }
            await entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            if (entity == null) { throw new ArgumentNullException("Data is not found"); }

            entities.Remove(entity);

            await SaveAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await entities.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int? id)
        {
            if(id == null) throw new ArgumentNullException();

            T entity = await entities.FindAsync(id);

            return entity ?? throw new NullReferenceException("Data is not found");
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity is null) throw new ArgumentNullException("Data is not found");
            entities.Update(entity);
            await SaveAsync();
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task SoftDeleteAsync(int? id)
        {
            if (id == null) throw new ArgumentNullException("Data is not found");
            var data = await GetByIdAsync(id);
            if (data == null) throw new NullReferenceException("Data is not found");
            data.SoftDelete = true;
            await SaveAsync();
        }
    }
}
