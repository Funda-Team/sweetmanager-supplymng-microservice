using SupplyMngService.Shared.Domain.Repositories;
using SupplyMngService.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace SupplyMngService.Shared.Infrastructure.Persistence.EFC.Repositories
{
    public class UnitOfWork(SupplymngContext context) : IUnitOfWork
    {
        public async Task CommitAsync() => await context.SaveChangesAsync();
    }
}