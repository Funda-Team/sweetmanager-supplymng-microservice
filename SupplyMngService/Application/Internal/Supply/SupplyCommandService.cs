﻿using SupplyMngService.Domain.Model.Commands;
using SupplyMngService.Domain.Model.Exceptions;
using SupplyMngService.Domain.Repositories;
using SupplyMngService.Domain.Services;
using SupplyMngService.Shared.Domain.Repositories;

namespace SupplyMngService.Application.Internal.Supply
{
    public class SupplyCommandService(ISupplyRepository supplyRepository, IUnitOfWork unitOfWork) : ISupplyCommandService
    {

        public async Task<bool> Handle(CreateSupplyCommand command)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(command.Name))
                    throw new InvalidSupplyNameException("The name of the supply cannot be empty.");

                if (command.Price <= 0)
                    throw new InvalidSupplyPriceException("The price of the supply must be greater than zero.");

                if (command.Stock < 0)
                    throw new InvalidSupplyStockException("The stock of the supply cannot be negative.");


                await supplyRepository.AddAsync(new Domain.Model.Aggregates.Supply(command));
                await unitOfWork.CommitAsync();

                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }


        public async Task<bool> Handle(UpdateSupplyCommand command)
        {
            try
            {
                var existingSupply = await supplyRepository.FindByIdAsync(command.Id);

                if (existingSupply == null)
                    throw new SupplyNotFoundException($"The supply with ID {command.Id} was not found.");


                if (string.IsNullOrWhiteSpace(command.Name))
                    throw new InvalidSupplyNameException("The name of the supply cannot be empty.");

                if (command.Price <= 0)
                    throw new InvalidSupplyPriceException("The price of the supply must be greater than zero.");

                if (command.Stock < 0)
                    throw new InvalidSupplyStockException("The stock of the supply cannot be negative.");


                existingSupply.Update(command);
                await unitOfWork.CommitAsync();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> Handle(DeleteSupplyCommand command)
        {
            try
            {
                var supplyToDelete = await supplyRepository.FindByIdAsync(command.Id);

                if (supplyToDelete == null)
                    throw new SupplyNotFoundException($"The supply with ID {command.Id} was not found.");


                supplyRepository.Remove(supplyToDelete);
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
