using Apollo.DTO;

namespace Apollo.Models;

public class Contract {
    public DateOnly Date { get; set; }
    public int Id { get; set; }
    public int ClientId { get; set; }
    public int UserId { get; set; }

    public Contract(int id, DateOnly date, int userId, int clientId)
    {
        Id = id;
        Date = date;
        UserId = userId;
        ClientId = clientId;
    }

    public ContractDTO ToContractDto(IEnumerable<Client> clients)
    {
        Client? client = clients.FirstOrDefault(cl => cl.Id == ClientId);
        string clientName = client is not null ? client.Name : string.Empty;
        ContractDTO contractDto = new (Id, Date, clientName);
        return contractDto;
    }
}