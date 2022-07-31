
using Pokedex.Enums;
using System.Text.Json.Serialization;

namespace Pokedex.Models;

// All in the same files, this is just used to map JSON to C# object, nothing more.

#region General

internal class LanguageJSON
{
    /// <summary> 2 letters lower ISO code </summary>
    [JsonPropertyName("name")]
    public string LanguageISOCode { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}

internal class RegionJSON
{
    [JsonPropertyName("name")]
    public RegionName Name { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}

internal class VersionGroupsJSON
{
    [JsonPropertyName("name")]
    public VersionGroup Name { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}

internal class VersionJSON
{
    [JsonPropertyName("name")]
    public PokemonVersion Name { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}

#endregion

#region Pokedex

internal class PokedexJSON
{
    [JsonPropertyName("descriptions")]
    public List<PokedexDescriptionJSON> Descriptions { get; set; }

    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("is_main_series")]
    public bool IsMainSerie { get; set; }

    [JsonPropertyName("name")]
    public RegionName Name { get; set; }


    [JsonPropertyName("names")]
    public List<PokedexNameJSON> Names { get; set; }


    [JsonPropertyName("pokemon_entries")]
    public List<PokedexPokemonJSON> Pokemons { get; set; }


    [JsonPropertyName("region")]
    public RegionJSON Region { get; set; }


    [JsonPropertyName("version_groups")]
    public List<VersionGroupsJSON> VersionGroups { get; set; }
}

internal class PokedexPokemonJSON
{
    [JsonPropertyName("entry_number")]
    public int PokemonId { get; set; }

    [JsonPropertyName("pokemon_species")]
    public PokemonSpeciesJSON Specie { get; set; }
}

internal class PokemonSpeciesJSON
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("url")]
    public List<LanguageJSON> Url { get; set; }
}

internal class PokedexDescriptionJSON
{
    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("language")]
    public List<LanguageJSON> Language { get; set; }
}

internal class PokedexNameJSON
{
    [JsonPropertyName("language")]
    public LanguageJSON Language { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }
}

#endregion

#region Pokemon

internal class PokemonJSON
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("base_experience")]
    public int BaseExperience { get; set; }

    [JsonPropertyName("height")]
    public int Height { get; set; }

    [JsonPropertyName("weight")]
    public int Weight { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("order")]
    public int Order { get; set; }


    [JsonPropertyName("abilities")]
    public List<AbilityJSON> Abilities { get; set; }

    [JsonPropertyName("held_items")]
    public List<HeldItemJSON> HeldItems { get; set; }

    [JsonPropertyName("moves")]
    public List<MoveJSON> Moves { get; set; }

    [JsonPropertyName("types")]
    public List<PokemonTypeJSON> Types { get; set; }

    [JsonPropertyName("past_types")]
    public List<PokemonPastTypeJSON> PastTypes { get; set; }

    [JsonPropertyName("stats")]
    public List<StatJSON> Stats { get; set; }

}

internal class AbilityJSON
{
    [JsonPropertyName("ability")]
    public AbilityNameJSON Name { get; set; }

    [JsonPropertyName("is_hidden")]
    public bool IsHidden { get; set; }

    [JsonPropertyName("slot")]
    public int Slot { get; set; }
}

internal class AbilityNameJSON
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}

internal class MoveJSON
{
    [JsonPropertyName("move")]
    public MoveNameJSON Name { get; set; }

    [JsonPropertyName("version_group_details")]
    public List<MoveVersionGroupJSON> DataByVersionGroup { get; set; }
}

internal class MoveNameJSON
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}

internal class MoveVersionGroupJSON
{
    [JsonPropertyName("level_learned_at")]
    public int LearnAtLevel { get; set; }

    [JsonPropertyName("move_learn_method")]
    public MoveLearnMethodJSON LearnMethod { get; set; }

    [JsonPropertyName("version_group")]
    public VersionGroupsJSON VersionGroup { get; set; }
}

internal class MoveLearnMethodJSON
{
    [JsonPropertyName("name")]
    public MoveLearnMethod Method { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}

internal class StatJSON
{
    [JsonPropertyName("base_stat")]
    public int BaseStat { get; set; }

    [JsonPropertyName("effort")]
    public int Effort { get; set; }

    [JsonPropertyName("stat")]
    public StatNameJSON Name { get; set; }
}

internal class StatNameJSON
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}

internal class PokemonTypeJSON
{
    [JsonPropertyName("slot")]
    public int Slot { get; set; }

    [JsonPropertyName("type")]
    public PokemonTypeNameJSON Type { get; set; }
}

internal class PokemonPastTypeJSON
{
    [JsonPropertyName("generation")]
    public GenerationNameJSON Generation { get; set; }

    [JsonPropertyName("types")]
    public List<PokemonTypeJSON> Types { get; set; }
}

internal class GenerationNameJSON
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}

internal class PokemonTypeNameJSON
{
    [JsonPropertyName("name")]
    public PokemonType Name { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}

internal class HeldItemJSON
{
    [JsonPropertyName("item")]
    public HeldItemNameJSON Item { get; set; }

    [JsonPropertyName("version_details")]
    public List<HeldItemVersionJSON> DetailByVersion { get; set; }
}

internal class HeldItemNameJSON
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}

internal class HeldItemVersionJSON
{
    [JsonPropertyName("rarity")]
    public int Rarity { get; set; }

    [JsonPropertyName("version")]
    public VersionJSON Version { get; set; }
}

#endregion

#region Encounters

internal class EncounterJSON
{
    [JsonPropertyName("location_area")]
    public LocationAreaJSON LocationArea { get; set; }

    [JsonPropertyName("version_details")]
    public List<EncounterVersionDetailsJSON> VersionDetails { get; set; }
}

internal class EncounterVersionDetailsJSON
{
    [JsonPropertyName("encounter_details")]
    public List<EncounterDetailJSON> Details { get; set; }

    [JsonPropertyName("max_chance")]
    public int MaxChance { get; set; }

    [JsonPropertyName("version")]
    public VersionJSON Version { get; set; }
}

internal class EncounterDetailJSON
{
    [JsonPropertyName("chance")]
    public int Chance { get; set; }

    [JsonPropertyName("max_level")]
    public int MaxLevel { get; set; }

    [JsonPropertyName("min_level")]
    public int MinLevel { get; set; }

    [JsonPropertyName("condition_values")]
    public List<EncounterConditionJSON> Conditions { get; set; }

    [JsonPropertyName("method")]
    public EncounterMethodJSON Method { get; set; }
}

internal class EncounterConditionJSON
{
    [JsonPropertyName("name")]
    public EncounterCondition Name { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}

internal class EncounterMethodJSON
{
    [JsonPropertyName("name")]
    public EncounterMethod Name { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}

internal class LocationAreaJSON 
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}

#endregion