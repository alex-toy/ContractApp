using Apollo.Models;
using RecrutementNet.Models;
using System;

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

    public Task Create(T entity)
    {
        _dbSet.Add(entity);
        return Task.CompletedTask;
    }

    public Task Update(int entityId, T entity)
    {
        T? entityToUpdate = Get(contract => contract.Id == entityId);
        if (entityToUpdate is not null) entityToUpdate = entity;
        return Task.CompletedTask;
    }

    public Task Delete(Func<T, bool> predicate)
    {
        _dbSet = _dbSet.Where(predicate).ToList();
        return Task.CompletedTask;
    }
}
