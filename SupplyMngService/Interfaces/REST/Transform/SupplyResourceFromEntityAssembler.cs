using SupplyMngService.Domain.Model.Aggregates;
using SupplyMngService.Interfaces.REST.Resources;

namespace SupplyMngService.Interfaces.REST.Transform
{
    public class SupplyResourceFromEntityAssembler
    {
        public static SupplyResource ToResourceFromEntity(Supply supply)
        {
            return new SupplyResource(supply.Id, supply.ProvidersId, supply.Name, supply.Price, supply.Stock, supply.State);
        }
    }
}
