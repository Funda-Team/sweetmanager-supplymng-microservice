using SupplyMngService.Domain.Model.Commands;
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

    public virtual ICollection<SuppliesRequest> SupplyRequests { get; set; } = new List<SuppliesRequest>();

    public Supply() { }

    public Supply(int id, int providersId, string name, decimal price, int stock, string state)
    {
        Id = id;
        ProvidersId = providersId;
        Name = name.ToUpper();
        Price = price;
        Stock = stock;
        State = state.ToUpper();
    }

    public Supply(CreateSupplyCommand command)
    {
        ProvidersId = command.ProvidersId;
        Name = command.Name.ToUpper();
        Price = command.Price;
        Stock = command.Stock;
        State = command.State.ToUpper();
    }

    public void Update(UpdateSupplyCommand command)
    {
        ProvidersId = command.ProvidersId;
        Name = command.Name.ToUpper();
        Price = command.Price;
        Stock = command.Stock;
        State = command.State.ToUpper();
    }
}