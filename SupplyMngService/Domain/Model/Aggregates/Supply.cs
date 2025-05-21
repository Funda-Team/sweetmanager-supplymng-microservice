using SupplyMngService.Domain.Model.Entities;

namespace SupplyMngService.Domain.Model.Aggregates;

public partial class Supply
{
    public int Id { get; set; }

    public int? ProvidersId { get; set; }

    public string? Name { get; set; }

    public decimal? Price { get; set; }

    public int? Stock { get; set; }

    public string? State { get; set; }

    public int? HotelsId { get; set; }

    public virtual ICollection<SupplyRequest> SupplyRequests { get; set; } = new List<SupplyRequest>();
}
