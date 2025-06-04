using SupplyMngService.Domain.Model.Aggregates;
using SupplyMngService.Domain.Model.Queries;

namespace SupplyMngService.Domain.Services
{
    public interface ISupplyQueryService
    {
        Task<Supply?> Handle(GetSupplyByIdQuery query);
        Task<IEnumerable<Supply>> Handle(GetAllSuppliesQuery query);
        Task<IEnumerable<Supply>> Handle(GetSupplyByProviderIdQuery query);
    }
}
