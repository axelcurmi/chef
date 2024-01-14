using Chef.Application.Services;

namespace Chef.Cli.Commands;

public class ListCommandHandler
{
    private readonly IMealService _mealService;

    public ListCommandHandler(IMealService mealService)
    {
        _mealService = mealService;
    }
    
    public async Task<int> Handle()
    {
        var meals = await _mealService.FindAll();
        
        Console.WriteLine($"{"ID",-32} {"Name"}");
        foreach (var meal in meals)
        {
            Console.WriteLine($"{meal.Id,-32} {meal.Name}");
        }
        return 0;
    }
}