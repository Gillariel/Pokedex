using Pokedex.Enums;

namespace Pokedex.Models;

/// <summary> Represent the data of a Move without context (Pkmn, Version, ...). It take a context when construct using <see cref="PokemonMoveDetails"/></summary>
public class PokemonMoveModel
{
    public string Name { get; set; }

    public int Power { get; set; }
    public int PP { get; set; }
    public int Accuracy { get; set; }
    public int Priority { get; set; }

    public PokemonType Type { get; set; }
    public DamageType DamageType { get; set; }
    public MoveTarget Target { get; set; }
    public MoveCategory Category { get; set; }

    public int? SpecificCritRate { get; set; }
    public int? Drain { get; set; }
    public int? Healing { get; set; }
    public int? MaxHits { get; set; }
    public int? MinHits { get; set; }
    public int? MaxTurns { get; set; }
    public int? MinTurns { get; set; }
    public int? FlinchChance { get; set; }
    public int? StatChance { get; set; }

    /// <summary> Key is the ailment type, Value is the chance to inflict the ailment, </summary>
    public KeyValuePair<Ailment, int>? Ailment { get; set; }

    /// <summary> Key is the targeted stat, Value is the modifier to apply to the stat (from -2 to +2), </summary>
    public Dictionary<CombatStat, int>? StatChanges { get; set; }

    // Not really useful for me but its possible to list the game where a move is a TM or an HM with its number, location, whatever
    // public List<TM_HM> TM_HM { get; set; }
}
