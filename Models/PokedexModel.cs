using Pokedex.Data;
using Pokedex.Enums;

namespace Pokedex.Models;

public class PokedexModel
{
    public int Id { get; private set; }

    /// <summary> Key is lang ISO code, Value is the translated name </summary>
    public Dictionary<string, string> Name { get; private set; }

    private IEnumerable<int> pokemonIds = new List<int>();
    public IEnumerable<PokemonModel> Pokemons { get => StaticData.Pokemons.Where(p => pokemonIds.Contains(p.Id)); }

    public RegionName Region { get; private set; }
    public List<VersionGroup> VersionGroup { get; private set; }

    public int Caught { get => Pokemons.Count(p => p.IsCaught); }
    public int Missing { get => Pokemons.Count(p => !p.IsCaught); }
    public decimal Progress { get => ((decimal)Caught / (decimal)Pokemons.Count()) * 100; }

    internal PokedexModel(PokedexJSON json)
    {
        Id              = json.Id;
        Name            = json.Names.ToDictionary(n => n.Language.LanguageISOCode, n => n.Name);
        Region          = json.Region.Name;
        VersionGroup    = json.VersionGroups.Select(v => v.Name).ToList();
        
        // We dont store a new list but use a ref to static data to safe memory
        pokemonIds      = json.Pokemons.Select(p => p.PokemonId);
    }
}