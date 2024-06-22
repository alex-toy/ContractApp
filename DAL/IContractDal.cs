using Apollo.DTO;
using Apollo.Models;

namespace RecrutementNet.DAL
{
    public interface IContractDal
    {
        Task DeleteAsync(string userId);
        IEnumerable<ContractDTO> GetContracts(int userId);
        IEnumerable<Contract> GetContractsBeforeDate(DateOnly date);
        IEnumerable<Contract> GetContractsByClientId(int id);
    }
}