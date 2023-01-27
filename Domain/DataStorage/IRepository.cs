using Domain.Models;

namespace Domain.DataStorage;

public interface IRepository<TModel> where TModel : ReadModel
{
    IEnumerable<TModel> GetAll();
    TModel GetById(Guid id);
    void Update(TModel newModel);
}