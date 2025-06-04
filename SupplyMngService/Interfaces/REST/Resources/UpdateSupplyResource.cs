namespace SupplyMngService.Interfaces.REST.Resources
{
    public record UpdateSupplyResource(int Id, int ProviderId, string Name, decimal Price, int Stock, string State);
}
