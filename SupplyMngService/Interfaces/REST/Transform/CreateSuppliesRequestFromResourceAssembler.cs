using SupplyMngService.Domain.Model.Commands;
using SupplyMngService.Interfaces.REST.Resources;

namespace SupplyMngService.Interfaces.REST.Transform
{
    public class CreateSuppliesRequestCommandFromResourceAssembler
    {
        public static CreateSuppliesRequestCommand ToCommandFromResource(CreateSuppliesRequestResource resource)
        {
            return new CreateSuppliesRequestCommand(
                resource.PaymentOwnerId,
                resource.SuppliesId,
                resource.Count,
                resource.Amount
            );
        }
    }
}
