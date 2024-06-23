namespace ContractApp.Shared.Exceptions;

public abstract class ContractAppException : Exception
{
    protected ContractAppException(string message) : base(message)
    {
    }
}
