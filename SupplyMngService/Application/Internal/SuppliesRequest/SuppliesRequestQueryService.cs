using SupplyMngService.Domain.Model.Queries;
using SupplyMngService.Domain.Repositories;
using SupplyMngService.Domain.Services;

namespace SupplyMngService.Application.Internal.SuppliesRequest
{
    public class SuppliesRequestQueryService(ISuppliesRequestRepository suppliesRequestRepository)
        : ISuppliesRequestQueryService
    {

        public async Task<Domain.Model.Entities.SuppliesRequest?> Handle(GetSuppliesRequestByIdQuery query)
        {
            return await suppliesRequestRepository.FindByIdAsync(query.Id);
        }

        public async Task<IEnumerable<Domain.Model.Entities.SuppliesRequest>> Handle(GetAllSuppliesRequestQuery query)
        {
            return await suppliesRequestRepository.FindAllSuppliesRequestsAsync(query.HotelId);
        }


        public async Task<Domain.Model.Entities.SuppliesRequest?> Handle(GetSuppliesRequestByPaymentOwnerIdQuery query)
        {
            return await suppliesRequestRepository.FindByPaymentOwnerId(query.PaymentOwnerId);
        }

        public async Task<Domain.Model.Entities.SuppliesRequest?> Handle(GetSuppliesRequestBySupplyIdQuery query)
        {
            return await suppliesRequestRepository.FindBySupplyId(query.SupplyId);
        }
    }
}
