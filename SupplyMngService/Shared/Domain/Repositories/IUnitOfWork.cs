namespace SupplyMngService.Shared.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}
