using Domain.Models;

namespace Domain.DataStorage;

public class InMemoryRepository<TModel> : IRepository<TModel> where TModel : ReadModel
{
    private readonly Dictionary<Guid, TModel> _collection;

    public InMemoryRepository()
    {
        _collection = new Dictionary<Guid, TModel>();
    }
    public Task<IEnumerable<TModel>> GetAll()
    {
        var models = _collection.Values.AsEnumerable();
        return Task.FromResult(models);
    }

    public Task<TModel> GetById(Guid id)
    {
        var model = _collection[id];
        return Task.FromResult(model);
    }

    public Task Create(TModel model)
    {
        if (_collection.ContainsKey(model.Id))
        {
            throw new Exception();
        }
        
        _collection.Add(model.Id, model);

        return Task.CompletedTask;
    }

    public Task Update(TModel model)
    {
        if (!_collection.ContainsKey(model.Id))
        {
            throw new Exception();
        }

        _collection[model.Id] = model;

        return Task.CompletedTask;
    }
}