using Apollo.DTO;
using RecrutementNet.Models;

namespace Apollo.Models;

public class Contract : Entity
{
    public DateOnly Date { get; set; }
    public int ClientId { get; set; }
    public int UserId { get; set; }

    public Contract(int id, DateOnly date, int userId, int clientId)
    {
        Id = id;
        Date = date;
        UserId = userId;
        ClientId = clientId;
    }

    public ContractDTO ToDto(string? clientName)
    {
        ContractDTO contractDto = new (Id, Date, clientName ?? string.Empty);
        return contractDto;
    }
}