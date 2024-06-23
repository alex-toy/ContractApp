using ContractApp.Shared.Exceptions;

namespace RecrutementNet.Exceptions.Clients;

public class TooShortClientNameException : ContractAppException
{
    public TooShortClientNameException(int minimalLength) : base($"Client name name should be more than {minimalLength} characters long.")
    {
    }
}
