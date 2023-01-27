using Domain.Models;

namespace Domain.DataStorage;

public interface IRepository<TModel> where TModel : ReadModel
{
    Task<IEnumerable<TModel>> GetAll();
    Task<TModel> GetById(Guid id);
    Task Create(TModel model);
    Task Update(TModel model);
}