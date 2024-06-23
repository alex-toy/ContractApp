using ContractApp.Shared.Exceptions;

namespace RecrutementNet.Exceptions.Clients;

public class InvalidAddressFormatException : ContractAppException
{
    public InvalidAddressFormatException() : base("Invalid address format : address should start with a number.")
    {
    }
}
