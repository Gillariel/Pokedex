
using Pokedex.Enums;

namespace Pokedex.Models;

public class PokemonEncounter
{
    public PokemonLocationArea Location { get; set; }
    public PokemonVersion Version { get; set; }

    /// <summary> Combined chance of all available levels of the same pokemon if more than one </summary>
    public int MaxChance { get; set; }
    public int MinimumLevel { get; set; }
    public int MaximumLevel { get; set; }
    public EncounterMethod EncounterMethod { get; set; }

    /// <summary> 
    ///  Some pokemon can be found with different levels in the same area. <br />
    ///  Usually the chance to found it with a greater level is less than lower level <br />
    ///  You can get the chance for a specific level using this list
    /// </summary>
    public List<ChanceByLevel> ChanceByLevel { get; set; }
}

public class ChanceByLevel
{
    public int Chance { get; set; }
    public int MinimumLevel { get; set; }
    public int MaximumLevel { get; set; }
    public List<EncounterCondition>? Conditions { get; set; }
    public EncounterMethod EncounterMethod { get; set; }
}

public class PokemonLocationArea
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Dictionary<string, string> NameByLang { get; set; }
    public Dictionary<string, string> LocationNameByLang { get; set; }
}