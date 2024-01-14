using Chef.Application.Services;
using Chef.Core.Entities;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Chef.Cli.Commands;

public class AddCommandHandler
{
    private readonly IMealService _mealService;

    public AddCommandHandler(IMealService mealService)
    {
        _mealService = mealService;
    }
    
    public async Task<int> Handle(string filepath)
    {
        if (!File.Exists(filepath))
        {
            await Console.Error.WriteLineAsync($"File '{filepath}' does not exists");
            return 1;
        }

        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(UnderscoredNamingConvention.Instance)
            .Build();
        var meal = deserializer.Deserialize<Meal>(await File.ReadAllTextAsync(filepath));

        await _mealService.Insert(meal);
        Console.WriteLine($"Meal added (digest:md5:{meal.Id})");
        
        return 0;
    }
}