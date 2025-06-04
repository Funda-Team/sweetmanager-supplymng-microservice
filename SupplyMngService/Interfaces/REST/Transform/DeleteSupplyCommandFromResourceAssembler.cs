using SupplyMngService.Domain.Model.Commands;
using SupplyMngService.Interfaces.REST.Resources;

namespace SupplyMngService.Interfaces.REST.Transform
{
    public class DeleteSupplyCommandFromResourceAssembler
    {
        public static DeleteSupplyCommand ToCommandFromResource(DeleteSupplyResource resource)
        {
            return new DeleteSupplyCommand(resource.Id);
        }
    }
}
