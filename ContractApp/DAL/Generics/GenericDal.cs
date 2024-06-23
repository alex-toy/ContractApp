using RecrutementNet.Models;

namespace RecrutementNet.DAL.Generics;

public class GenericDal<T> : IGenericDal<T> where T : Entity
{
    protected ICollection<T> _dbSet;

    public GenericDal(ICollection<T> contractDbSet)
    {
        _dbSet = contractDbSet;
    }

    public T? Get(Func<T, bool> predicate)
    {
        return _dbSet.FirstOrDefault(predicate);
    }

    public IEnumerable<T> GetAll(Func<T, bool>? predicate = null)
    {
        return predicate is not null ? _dbSet.Where(predicate) : _dbSet;
    }

    public Task<int> Create(T entity)
    {
        int maxId = _dbSet.Max(entity =>  entity.Id);
        entity.Id = maxId + 1;
        _dbSet.Add(entity);
        return Task.FromResult(entity.Id);
    }

    public Task Update(T entity)
    {
        T? entityToUpdate = Get(e => e.Id == entity.Id);
        if (entityToUpdate is not null)
        {
            _dbSet.Remove(entityToUpdate);
            _dbSet.Add(entity);
        }
            
        return Task.CompletedTask;
    }

    public Task Delete(Func<T, bool> predicate)
    {
        T? entityToRemove = Get(predicate);
        if (entityToRemove is not null) _dbSet.Remove(entityToRemove);

        return Task.CompletedTask;
    }
}
