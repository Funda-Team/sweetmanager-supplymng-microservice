namespace SupplyMngService.Domain.Model.Commands
{
    public record UpdateSupplyCommand(int Id, int ProvidersId, string Name, decimal Price, int Stock, string State);
}
