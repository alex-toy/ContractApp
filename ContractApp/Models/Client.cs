using RecrutementNet.DTO.Clients;
using RecrutementNet.Models;
using RecrutementNet.ValueObjects;

namespace Apollo.Models;

public class Client : Entity
{
    public ClientName Name { get; set; }
    public string Address { get; set; }

    public Client(int id, ClientName name, string address)
    {
        Address = address;
        Name = name;
        Id = id;
    }

    public ClientDTO ToDto() => new(Id, Name, Address);
}