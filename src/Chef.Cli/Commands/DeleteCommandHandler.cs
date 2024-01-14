using Chef.Application.Services;

namespace Chef.Cli.Commands;

public class DeleteCommandHandler
{
    private readonly IMealService _mealService;

    public DeleteCommandHandler(IMealService mealService)
    {
        _mealService = mealService;
    }
    
    public async Task<int> Handle(string toDelete)
    {
        var meal = await _mealService.FindById(toDelete);
        if (meal != null)
        {
            await _mealService.Delete(meal);
            Console.WriteLine($"{meal.Id} deleted");
            return 0;
        }

        meal = await _mealService.FindBySlug(toDelete);
        if (meal != null)
        {
            await _mealService.Delete(meal);
            Console.WriteLine($"{meal.Id} deleted");
            return 0;
        }

        await Console.Error.WriteLineAsync("Invalid meal ID or name");
        
        return 1;
    }
}