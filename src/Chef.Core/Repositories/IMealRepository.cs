using Chef.Core.Entities;

namespace Chef.Core.Repositories;

public interface IMealRepository
{
    Task<IEnumerable<Meal>> FindAll();
    Task<Meal> FindById(string id);
    Task<Meal> FindByName(string name);
    Task Insert(Meal meal);
    Task Delete(Meal meal);
}