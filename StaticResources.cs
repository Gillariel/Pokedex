
namespace Pokedex;

/// <summary> All resources ended with a / so that you can add id without adding the DirectorySeparatorChar yourself </summary>
public class StaticResources
{
    public static readonly string Images                = $"{FileSystem.CacheDirectory}{Path.DirectorySeparatorChar}Images{Path.DirectorySeparatorChar}";
    public static readonly string PokemonSprites        = $"{Images}Pokemon{Path.DirectorySeparatorChar}Home{Path.DirectorySeparatorChar}";
    public static readonly string ShinySprites          = $"{PokemonSprites}Shiny{Path.DirectorySeparatorChar}";
    public static readonly string ShinyFemaleSprites    = $"{ShinySprites}Female{Path.DirectorySeparatorChar}";
    public static readonly string FemaleSprites         = $"{PokemonSprites}Female{Path.DirectorySeparatorChar}";
    public static readonly string PokemonDetails        = $"{FileSystem.CacheDirectory}{Path.DirectorySeparatorChar}Details{Path.DirectorySeparatorChar}";
    public static readonly string Pokedexes             = $"{FileSystem.CacheDirectory}{Path.DirectorySeparatorChar}Pokedexes{Path.DirectorySeparatorChar}";
    public static readonly string ItemSprites           = $"{Images}Items{Path.DirectorySeparatorChar}";
}
