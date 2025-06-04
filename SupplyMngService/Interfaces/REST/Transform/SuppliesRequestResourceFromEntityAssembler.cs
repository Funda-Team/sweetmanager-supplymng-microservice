using SupplyMngService.Domain.Model.Entities;
using SupplyMngService.Interfaces.REST.Resources;

namespace SupplyMngService.Interfaces.REST.Transform
{
    public class SuppliesRequestResourceFromEntityAssembler
    {
        public static SuppliesRequestResource ToResourceFromEntity(SuppliesRequest resource)
        {
            return new SuppliesRequestResource(resource.Id, resource.PaymentOwnerId, resource.SuppliesId, resource.Count, resource.Amount);
        }
    }
}
