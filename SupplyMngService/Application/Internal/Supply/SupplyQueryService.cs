using SupplyMngService.Domain.Model.Queries;
using SupplyMngService.Domain.Repositories;
using SupplyMngService.Domain.Services;

namespace SupplyMngService.Application.Internal.Supply
{
    public class SupplyQueryService(ISupplyRepository supplyRepository) : ISupplyQueryService
    {
        public async Task<Domain.Model.Aggregates.Supply?> Handle(GetSupplyByIdQuery query)
        {
            return await supplyRepository.FindByIdAsync(query.Id);
        }

        public async Task<IEnumerable<Domain.Model.Aggregates.Supply>> Handle(GetAllSuppliesQuery query)
        {
            return await supplyRepository.FindSuppliesByHotelIdAsync(query.HotelId);
        }

        public async Task<IEnumerable<Domain.Model.Aggregates.Supply>> Handle(GetSupplyByProviderIdQuery query)
        {
            return await supplyRepository.FindByProvidersId(query.ProviderId);
        }
    }
}
