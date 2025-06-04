namespace SupplyMngService.Interfaces.REST.Resources
{
    public record SupplyResource(int Id, int? ProviderId, string? Name, decimal? Price, int? Stock, string? State);
}
