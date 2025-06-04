using SupplyMngService.Domain.Model.Commands;
using SupplyMngService.Interfaces.REST.Resources;

namespace SupplyMngService.Interfaces.REST.Transform
{
    public class CreateSupplyCommandFromResourceAssembler
    {
        public static CreateSupplyCommand ToCommandFromResource(CreateSupplyResource resource)
        {
            return new CreateSupplyCommand(resource.ProviderId, resource.Name, resource.Price, resource.Stock, resource.State);
        }
    }
}
