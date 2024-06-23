namespace Apollo.DTO;

public class ContractDTO {
    public ContractDTO(int id, DateOnly date, string clientName)
    {
        Id = id;
        Date = date;
        ClientName = clientName;
    }

    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public string ClientName { get; set; }
}