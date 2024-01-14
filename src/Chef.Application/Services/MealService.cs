using Chef.Core.Entities;
using Chef.Core.Repositories;

namespace Chef.Application.Services;

public class MealService : IMealService
{
    private readonly IMealRepository _mealRepository;

    public MealService(IMealRepository mealRepository)
    {
        _mealRepository = mealRepository;
    }
    
    public async Task<IEnumerable<Meal>> FindAll()
    {
        return await _mealRepository.FindAll();
    }

    public async Task<Meal?> FindById(string id)
    {
        return await _mealRepository.FindById(id);
    }

    public async Task<Meal?> FindBySlug(string slug)
    {
        return await _mealRepository.FindBySlug(slug);
    }

    public async Task Insert(Meal meal)
    {
        await _mealRepository.Insert(meal);
    }

    public async Task Delete(Meal meal)
    {
        await _mealRepository.Delete(meal);
    }
}