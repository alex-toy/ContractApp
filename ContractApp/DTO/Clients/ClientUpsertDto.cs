using Apollo.Models;

namespace RecrutementNet.DTO.Clients;

public class ClientUpsertDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }

    public Client ToModel()
    {
        return new Client(Id, Name, Address);
    }
}
