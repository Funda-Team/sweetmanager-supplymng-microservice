using SupplyMngService.Domain.Model.Aggregates;

namespace SupplyMngService.Domain.Model.Entities;

public partial class SupplyRequest
{
    public int Id { get; set; }

    public int? PaymentOwnersId { get; set; }

    public int? SuppliesId { get; set; }

    public int? Count { get; set; }

    public decimal? Amount { get; set; }

    public virtual Supply? Supplies { get; set; }
}
