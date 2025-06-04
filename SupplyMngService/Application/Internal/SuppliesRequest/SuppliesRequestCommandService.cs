using SupplyMngService.Domain.Model.Commands;
using SupplyMngService.Domain.Model.Exceptions;
using SupplyMngService.Domain.Repositories;
using SupplyMngService.Domain.Services;
using SupplyMngService.Shared.Domain.Repositories;

namespace SupplyMngService.Application.Internal.SuppliesRequest
{
    public class SuppliesRequestCommandService(
        ISuppliesRequestRepository suppliesRequestRepository,
        ISupplyRepository supplyRepository,
        IUnitOfWork unitOfWork)
        : ISuppliesRequestCommandService
    {
        public async Task<bool> Handle(CreateSuppliesRequestCommand command)
        {
            try
            {

                if (command.Count <= 0)
                    throw new InvalidSuppliesRequestCountException("The count must be greater than zero.");


                if (command.Amount <= 0)
                    throw new InvalidSuppliesRequestAmountException("The amount must be greater than zero.");


                var supply = await supplyRepository.FindByIdAsync(command.SuppliesId);
                if (supply == null)
                    throw new SupplyNotFoundException($"The supply with ID {command.SuppliesId} was not found.");



                var suppliesRequest = new Domain.Model.Entities.SuppliesRequest(command);

                await suppliesRequestRepository.AddAsync(suppliesRequest);

                await unitOfWork.CommitAsync();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
