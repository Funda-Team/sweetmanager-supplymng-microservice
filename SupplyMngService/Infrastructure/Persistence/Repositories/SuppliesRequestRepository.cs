using Microsoft.EntityFrameworkCore;
using SupplyMngService.Domain.Model.Aggregates;
using SupplyMngService.Domain.Model.Entities;
using SupplyMngService.Domain.Repositories;
using SupplyMngService.Shared.Infrastructure.Persistence.EFC.Configuration;
using SupplyMngService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace SupplyMngService.Infrastructure.Persistence.Repositories
{
    public class SuppliesRequestRepository(SupplymngContext context) : BaseRepository<SuppliesRequest>(context), ISuppliesRequestRepository
    {
        public async Task<SuppliesRequest?> FindBySupplyId(int supplyId)
        => await Context.Set<SuppliesRequest>().FirstOrDefaultAsync(f => f.SuppliesId == supplyId);


        public async Task<SuppliesRequest?> FindByPaymentOwnerId(int paymentOwnerId)
        => await Context.Set<SuppliesRequest>().FirstOrDefaultAsync(f => f.PaymentOwnerId == paymentOwnerId);
        

        public async Task<IEnumerable<SuppliesRequest>> FindAllSuppliesRequestsAsync(int queryHotelId)
        => await Task.Run(() => (
                from sp in Context.Set<SuppliesRequest>().ToList()
                join ss in Context.Set<Supply>().ToList()
                    on sp.SuppliesId equals ss.Id
                where ss.HotelsId.Equals(queryHotelId)
                select sp
            ).ToList());

    }
}
