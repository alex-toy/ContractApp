using ContractApp.Shared;
using RecrutementNet.DTO.Clients;

namespace Apollo.Models;

public class Client : Entity
{
    public string Name { get; set; }
    public string Address { get; set; }

    public Client(int id, string name, string address)
    {
        Id = id;
        Name = name;
        Address = address;
    }

    public ClientDTO ToDto() => new(Id, Name, Address);
}