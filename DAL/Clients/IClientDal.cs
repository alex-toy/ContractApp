using Apollo.Models;

namespace RecrutementNet.DAL.Clients
{
    public interface IClientDal
    {
        Client? Get(Func<Client, bool> predicate);
        IEnumerable<Client> GetAll(Func<Client, bool> predicate);
    }
}