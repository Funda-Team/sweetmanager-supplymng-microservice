using SupplyMngService.Domain.Model.Aggregates;
using SupplyMngService.Shared.Domain.Repositories;

namespace SupplyMngService.Domain.Repositories
{
    public interface ISupplyRepository : IBaseRepository<Supply>
    {
        public Task<IEnumerable<Supply>> FindByProvidersId(int providersId);

        public Task<IEnumerable<Supply>> FindSuppliesByHotelIdAsync(int hotelId);

    }
}
