using ContractApp.Shared.Exceptions;

namespace RecrutementNet.Exceptions.Clients;

public class EmptyClientNameException : ContractAppException
{
    public EmptyClientNameException() : base("Client name cannot be empty.")
    {
    }
}
