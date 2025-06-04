using SupplyMngService.Domain.Model.Entities;
using SupplyMngService.Shared.Domain.Repositories;

namespace SupplyMngService.Domain.Repositories
{
    public interface ISuppliesRequestRepository : IBaseRepository<SuppliesRequest>
    {
        public Task<SuppliesRequest?> FindBySupplyId(int supplyId);

        public Task<SuppliesRequest?> FindByPaymentOwnerId(int paymentOwnerId);

        public Task<IEnumerable<SuppliesRequest>> FindAllSuppliesRequestsAsync(int HotelId);
    }
}
