using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Chef.Core.Entities;

public class Meal
{
    private string _name = string.Empty;

    public string Id { get; private set; } = string.Empty;
    public string Slug { get; private set; } = string.Empty;
    
    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            Id = Convert.ToHexString(
                MD5.HashData(
                    Encoding.UTF8.GetBytes(_name))).ToLower();

            var slug = Name.ToLower();
            slug = Regex.Replace(slug, @"[^a-z0-9\s]", "");
            slug = Regex.Replace(slug, @"\s{2,}", " ").Trim();
            slug = Regex.Replace(slug, @"\s", "-");
            Slug = slug;
        }
    }
    public IEnumerable<string> Ingredients { get; set; } = new List<string>();
}