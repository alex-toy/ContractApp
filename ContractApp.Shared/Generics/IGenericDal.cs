namespace ContractApp.Shared.Generics;

public interface IGenericDal<T> where T : Entity
{
    T? Get(Func<T, bool> predicate);
    IEnumerable<T> GetAll(Func<T, bool>? predicate = null);
    Task Delete(Func<T, bool> predicate);
    Task<int> Create(T entity);
    Task Update(T entity);
}