namespace SupplyMngService.Domain.Model.Exceptions
{
    public class SupplyNotFoundException : Exception
    {
        public SupplyNotFoundException(string message) : base(message)
        {
        }
    }
}
