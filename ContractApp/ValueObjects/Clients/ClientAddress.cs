using RecrutementNet.Exceptions.Clients;
using System.Text.RegularExpressions;

namespace RecrutementNet.ValueObjects.Clients;

public class ClientAddress
{
    public string Value { get; }

    public ClientAddress(string value)
    {
        if (!Regex.IsMatch(value, "^\\d.+")) throw new InvalidAddressFormatException();

        Value = value;
    }

    public static implicit operator string(ClientAddress name) => name.Value;

    public static implicit operator ClientAddress(string name) => new(name);
}
