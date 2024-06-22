using RecrutementNet.Models;

namespace RecrutementNet.DAL.Generics
{
    public interface IGenericDal<T> where T : Entity
    {
        T? Get(Func<T, bool> predicate);
        IEnumerable<T> GetAll(Func<T, bool>? predicate = null);
        Task Delete(Func<T, bool> predicate);
        Task Create(T entity);
        Task Update(int entityId, T entity);
    }
}