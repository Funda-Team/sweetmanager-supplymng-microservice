using System;
using System.Collections.Generic;

namespace SupplyMngService;

public partial class SupplyRequest
{
    public int Id { get; set; }

    public int? PaymentOwnersId { get; set; }

    public int? SuppliesId { get; set; }

    public int? Count { get; set; }

    public decimal? Amount { get; set; }

    public virtual Supply? Supplies { get; set; }
}
