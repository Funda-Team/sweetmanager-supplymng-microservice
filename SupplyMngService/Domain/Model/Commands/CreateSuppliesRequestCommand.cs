namespace SupplyMngService.Domain.Model.Commands
{    public record CreateSuppliesRequestCommand(int PaymentOwnerId, int SuppliesId, int Count, decimal Amount);
}
