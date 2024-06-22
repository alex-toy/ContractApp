namespace RecrutementNet.DTO;

public class ClientDTO
{
    public ClientDTO(string name, string address)
    {
        Name = name;
        Address = address;
    }

    public string Name { get; set; }
    public string Address { get; set; }
}
