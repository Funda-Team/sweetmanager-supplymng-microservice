using SupplyMngService.Domain.Model.Commands;
using SupplyMngService.Interfaces.REST.Resources;

namespace SupplyMngService.Interfaces.REST.Transform
{
    public class UpdateSupplyCommandFromResource
    {
        public static UpdateSupplyCommand FromResource(int Id, UpdateSupplyResource resource)
        {
            return new UpdateSupplyCommand(Id, resource.ProviderId, resource.Name, resource.Price, resource.Stock, resource.State);
        }
    }
}
