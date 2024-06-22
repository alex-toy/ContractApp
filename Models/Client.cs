using RecrutementNet.DTO;
using RecrutementNet.Models;

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