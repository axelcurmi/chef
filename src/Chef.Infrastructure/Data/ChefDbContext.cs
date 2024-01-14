using Chef.Core.Entities;
using LiteDB;

namespace Chef.Infrastructure.Data;

internal class ChefDbContext : IDisposable
{
    private ILiteDatabase _context;
    
    public ILiteCollection<Meal> Meals { get; private set; }

    public ChefDbContext(string connectionString)
    {
        _context = new LiteDatabase(connectionString);
        Meals = _context.GetCollection<Meal>();
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }
}