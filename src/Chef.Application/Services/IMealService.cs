using Chef.Core.Entities;

namespace Chef.Application.Services;

public interface IMealService
{
    Task<IEnumerable<Meal>> FindAll();
    Task<Meal?> FindById(string id);
    Task<Meal?> FindByName(string name);
    Task Insert(Meal meal);
    Task Delete(Meal meal);
}