using SupplyMngService.Domain.Model.Entities;
using SupplyMngService.Domain.Model.Queries;

namespace SupplyMngService.Domain.Services
{
    public interface ISuppliesRequestQueryService
    {
        Task<SuppliesRequest?> Handle(GetSuppliesRequestByIdQuery query);

        Task<IEnumerable<SuppliesRequest>> Handle(GetAllSuppliesRequestQuery query);

        Task<SuppliesRequest?> Handle(GetSuppliesRequestByPaymentOwnerIdQuery query);

        Task<SuppliesRequest?> Handle(GetSuppliesRequestBySupplyIdQuery query);

    }
}
