using Microsoft.EntityFrameworkCore;
using SupplyMngService.Shared.Domain.Repositories;
using SupplyMngService.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace SupplyMngService.Shared.Infrastructure.Persistence.EFC.Repositories
{
    public abstract class BaseRepository<TEntity>(SupplymngContext context) : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly SupplymngContext Context = context;

        public async Task AddAsync(TEntity entity) => await Context.Set<TEntity>().AddAsync(entity);

        public async Task<TEntity?> FindByIdAsync(int id) => await Context.Set<TEntity>().FindAsync(id);

        public async Task<IEnumerable<TEntity>> ListAsync() => await Context.Set<TEntity>().ToListAsync();

        public void Remove(TEntity entity) => Context.Set<TEntity>().Remove(entity);

        public void Update(TEntity entity) => Context.Set<TEntity>().Update(entity);
    }
}