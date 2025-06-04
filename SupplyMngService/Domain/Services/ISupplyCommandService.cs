using SupplyMngService.Domain.Model.Commands;

namespace SupplyMngService.Domain.Services
{
    public interface ISupplyCommandService
    {
        Task<bool> Handle(CreateSupplyCommand command);
        Task<bool> Handle(UpdateSupplyCommand command);
        Task<bool> Handle(DeleteSupplyCommand command);
    }
}
