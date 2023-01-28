using Domain.Models;
using MongoDB.Driver;

namespace Domain.DataStorage;

public class MongoRepository<T> : IRepository<T> where T : ReadModel
{
    private readonly IMongoCollection<T> _collection;

    public MongoRepository()
    {
        var client = new MongoClient("mongodb://root:example@mongo:27017");
        var db = client.GetDatabase("BugTracker");
        _collection = db.GetCollection<T>(nameof(T));
    }
    
    public async Task<IEnumerable<T>> GetAll()
    {
        var allModels = await _collection.FindAsync(m => true);
        return allModels.ToList();
    }

    public async Task<T> GetById(Guid id)
    {
        var model = await _collection.FindAsync(t => t.Id == id);
        return model.Single();
    }

    public async Task Create(T model)
    {
        await _collection.InsertOneAsync(model);
    }

    public async Task Update(T model)
    {
        await _collection.ReplaceOneAsync(m => m.Id == model.Id, model);
    }
}