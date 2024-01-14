using System.Security.Cryptography;
using System.Text;

namespace Chef.Core.Entities;

public class Meal
{
    private string _name = string.Empty;

    public string Id { get; private set; } = string.Empty;
    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            Id = Convert.ToHexString(
                MD5.HashData(
                    Encoding.UTF8.GetBytes(_name)));
        }
    }
    public IEnumerable<string> Ingredients { get; set; } = new List<string>();
}