using SupplyMngService.Domain.Model.Commands;

namespace SupplyMngService.Domain.Services
{
    public interface ISuppliesRequestCommandService
    {
        Task<bool> Handle(CreateSuppliesRequestCommand command);
    }
}
