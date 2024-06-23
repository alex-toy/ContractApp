using ContractApp.Shared;
using RecrutementNet.DTO.Clients;
using RecrutementNet.ValueObjects;

namespace Apollo.Models;

public class Client : Entity
{
    public string Name { get; set; }
    public string Address { get; set; }

    public Client(int id, string name, string address)
    {
        Address = address;
        Name = name;
        Id = id;
    }

    public ClientDTO ToDto() => new(Id, Name, Address);
}