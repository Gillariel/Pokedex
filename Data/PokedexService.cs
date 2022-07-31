using Pokedex.Enums;
using Pokedex.Models;
using System.IO.Compression;
using System.Text.Json;

namespace Pokedex.Data;

public static class PokedexDI
{
    public static IServiceCollection AddData(this IServiceCollection services)
    {
        services.AddScoped<PokedexService>();
        return services;
    }
}

public class PokedexService
{
    public IReadOnlyList<PokemonModel> ListPokemons()
        => StaticData.Pokemons;

    public IReadOnlyList<PokedexModel> ListPokedex()
        => StaticData.Pokedexes;

    public PokemonModel GetPokemon(int id)
        => StaticData.Pokemons.FirstOrDefault(p => p.Id == id);

    public PokedexModel GetPokedex(int id)
        => StaticData.Pokedexes.FirstOrDefault(p => p.Id == id);
}

/// <summary> Fake DI, flemme. Readonly collections with private setters are pretty safe. </summary>
public static class StaticData
{
    /// <summary> Key is {ID}_{LANG} (for quickier access), Value is the translated name </summary>
    public static IReadOnlyDictionary<string, string> PokemonDetailsFilesPath { get; private set; }

    public static IReadOnlyList<PokedexModel>        Pokedexes { get; private set; }
    public static IReadOnlyList<PokemonModel>        Pokemons { get; private set; }
    public static IReadOnlyList<PokemonItemModel>    Items { get; private set; }
    public static IReadOnlyList<PokemonMoveModel>    Moves { get; private set; }
    public static IReadOnlyList<PokemonAbility>      Abilities { get; private set; }
    public static IReadOnlyList<PokemonLocationArea> LocationArea { get; private set; }

    public static void Load()
    {
        // Seems MAUI not handled file loading directly from build folder without having its exact name (its not possible to list files or folder)
        // So downloads tha resources at start is the quickier way...
        if (!Directory.Exists(Path.Combine(FileSystem.CacheDirectory, "Images")))
            return;

        // TODO: Load translated name of pkmn as a single Dic
        var pokemonsPath = Directory.GetFiles(StaticResources.PokemonDetails);
        var pokemons = new List<PokemonModel>();
        foreach (var pokemonPath in pokemonsPath)
        {
            var pokemonString = File.ReadAllText(pokemonPath);
            var pokemon = JsonSerializer.Deserialize<PokemonJSON>(pokemonString);

            var fileNameIdentifcier = pokemonPath.Split(Path.DirectorySeparatorChar).LastOrDefault()?.Split(".json")?[0] ?? "N/A";
            var encounterPath = pokemonsPath.FirstOrDefault(f => f.StartsWith(fileNameIdentifcier) && f.Contains("-encounters"));
            var pokemonEncounters = !string.IsNullOrEmpty(encounterPath)
                ? JsonSerializer.Deserialize<List<EncounterJSON>>(pokemonString)
                : null;

            if (pokemon != null && pokemon.Id > 0)
                pokemons.Add(new PokemonModel(pokemon, pokemonEncounters));
        }

        var pokedexPaths = Directory.GetFiles(StaticResources.Pokedexes);
        var pokedexes = new List<PokedexModel>();
        foreach (var pokedexPath in pokedexPaths)
        {
            var pokedexString = File.ReadAllText(pokedexPath);
            var pokedex = JsonSerializer.Deserialize<PokedexJSON>(pokedexString);
            if (pokedex != null && Enum.IsDefined(typeof(RegionName), pokedex.Name))
                pokedexes.Add(new PokedexModel(pokedex));
        }

        Pokemons  = pokemons;
        Pokedexes = pokedexes;
    }

    public static async Task<bool> DownloadAssets(HttpClient client)
    {
        try
        {
            // Download and store the zip with all resources
            byte[] fileBytes = await client.GetByteArrayAsync(@"https://url.com/filename.png");
            File.WriteAllBytes(Path.Combine(FileSystem.CacheDirectory, "resources.zip"), fileBytes);

            // Unzip the files
            ZipFile.ExtractToDirectory(Path.Combine(FileSystem.CacheDirectory, "resources.zip"), FileSystem.CacheDirectory);

            // Delete the zip
            File.Delete(Path.Combine(FileSystem.CacheDirectory, "resources.zip"));
            return true;
        }
        catch (Exception) { return false; }
    }
}