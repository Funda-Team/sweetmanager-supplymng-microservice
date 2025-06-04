namespace SupplyMngService.Interfaces.REST.Resources
{    public record CreateSuppliesRequestResource(int PaymentOwnerId, int SuppliesId, int Count, decimal Amount);
}
