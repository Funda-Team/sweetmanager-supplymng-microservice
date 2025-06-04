using SupplyMngService.Domain.Model.Aggregates;
using SupplyMngService.Domain.Model.Commands;

namespace SupplyMngService.Domain.Model.Entities;

public partial class SuppliesRequest
{
    public int Id { get; set; }

    public int? PaymentOwnerId { get; set; }

    public int? SuppliesId { get; set; }

    public int? Count { get; set; }

    public decimal? Amount { get; set; }

    public virtual Supply? Supplies { get; set; }


    public SuppliesRequest() { }

    public SuppliesRequest(int id, int paymentsOwnersId, int suppliesId, int count, decimal amount)
    {
        Id = id;
        PaymentOwnerId = paymentsOwnersId;
        SuppliesId = suppliesId;
        Count = count;
        Amount = amount;
    }

    public SuppliesRequest(CreateSuppliesRequestCommand command)
    {
        PaymentOwnerId = command.PaymentOwnerId;
        SuppliesId = command.SuppliesId;
        Count = command.Count;
        Amount = command.Amount;
    }
}
