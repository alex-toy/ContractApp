using Apollo.Data;
using Apollo.Models;
using ContractApp.Shared.Generics;

namespace RecrutementNet.DAL.Clients;

public class ClientDal : GenericDal<Client>
{
    public ClientDal() : base(ClientsDbSet.Data)
    {
    }
}
