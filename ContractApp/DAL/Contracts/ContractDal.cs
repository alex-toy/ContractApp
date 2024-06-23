using Apollo.Data;
using Apollo.Models;
using ContractApp.Shared.Generics;

namespace RecrutementNet.DAL.Contracts;

public class ContractDal : GenericDal<Contract>
{
    public ContractDal() : base(ContractsDbSet.Data)
    {
    }
}