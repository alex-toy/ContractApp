namespace Apollo.Models;

public class Client {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }

    public Client(int id, string name, string address)
    {
        Address = address;
        Name = name;
        Id = id;
    }
}