namespace SupplyMngService.Interfaces.REST.Resources
{
    public record CreateSupplyResource(int ProviderId, string Name, decimal Price, int Stock, string State);
}
