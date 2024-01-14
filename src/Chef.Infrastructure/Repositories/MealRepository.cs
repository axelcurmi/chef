using Chef.Core.Entities;
using Chef.Core.Repositories;
using Chef.Infrastructure.Data;

namespace Chef.Infrastructure.Repositories;

internal class MealRepository : IMealRepository
{
    private readonly ChefDbContext _context;

    public MealRepository(ChefDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Meal>> FindAll()
    {
        return await Task.Run(() => _context.Meals.FindAll());
    }

    public async Task<Meal> FindById(string id)
    {
        return await Task.Run(() => _context.Meals.FindOne(m => m.Id == id || m.Id.StartsWith(id)));
    }

    public async Task<Meal> FindBySlug(string slug)
    {
        return await Task.Run(() => _context.Meals.FindOne(m => m.Slug == slug));
    }

    public async Task Insert(Meal meal)
    {
        await Task.Run(() => _context.Meals.Insert(meal));
    }

    public async Task Delete(Meal meal)
    {
        await Task.Run(() => _context.Meals.Delete(meal.Id));
    }
}