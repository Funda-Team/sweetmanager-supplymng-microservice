using Microsoft.EntityFrameworkCore;
using SupplyMngService.Domain.Model.Aggregates;
using SupplyMngService.Domain.Model.Entities;
using SupplyMngService.Domain.Repositories;
using SupplyMngService.Shared.Infrastructure.Persistence.EFC.Configuration;
using SupplyMngService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace SupplyMngService.Infrastructure.Persistence.Repositories
{
    public class SupplyRepository : BaseRepository<Supply>, ISupplyRepository
    {
        public SupplyRepository(SupplymngContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Supply>> FindByProvidersId(int providersId)
        => await Context.Set<Supply>().Where(s => s.ProvidersId == providersId).ToListAsync();
         

        public async Task<IEnumerable<Supply>> FindSuppliesByHotelIdAsync(int hotelId)
        => await Task.Run(() => (
                from supply in Context.Set<Supply>().ToList()
                where supply.HotelsId.Equals(hotelId)
                select supply
            ).ToList());
        
    }
}
