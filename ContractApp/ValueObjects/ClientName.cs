using RecrutementNet.Exceptions.Clients;

namespace RecrutementNet.ValueObjects;

public class ClientName
{
    public string Value { get; }

    private int _minimalLength = 3;
    private int _maximalLength = 10;

    public ClientName(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new EmptyClientNameException();
        if (value.Length < _minimalLength) throw new TooShortClientNameException(_minimalLength);
        if (value.Length > _maximalLength) throw new TooLongClientNameException(_maximalLength);

        Value = value;
    }

    public static implicit operator string(ClientName name) => name.Value;

    public static implicit operator ClientName(string name) => new(name);
}
