
using Apollo.Models;

namespace Apollo.Data;


static class ClientsDbSet
{
    public static List<Client> Data = new() {
        new(1, "Client 1", "Address 1"),
        new(1, "Client 2", "Address 2"),
        new(1, "Client 3", "Address 3")
    };
}