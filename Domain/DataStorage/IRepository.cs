namespace Domain.DataStorage;

public interface IRepository<TModel> where TModel : ReadModel
{
    Task<IEnumerable<TModel>> GetAll();
    Task<TModel> GetById(Guid id);
    Task Create(TModel bug);
    Task Update(TModel newModel);
}