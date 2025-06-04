namespace SupplyMngService.Domain.Model.Exceptions
{
    public class InvalidSuppliesRequestCountException : Exception
    {
        public InvalidSuppliesRequestCountException(string message) : base(message)
        {
        }
    }
}
