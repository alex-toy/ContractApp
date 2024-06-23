using ContractApp.Shared.Exceptions;

namespace RecrutementNet.Exceptions.Clients
{
    public class TooLongClientNameException : ContractAppException
    {
        public TooLongClientNameException(int maximalLength) : base($"Client name name should be no more than {maximalLength} characters long.")
        {
        }
    }
}
