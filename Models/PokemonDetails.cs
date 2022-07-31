using Pokedex.Data;
using Pokedex.Enums;

namespace Pokedex.Models;

public class PokemonDetails
{
    public int Weight { get; set; }
    public int Height { get; set; }

    public int BaseExperience { get; set; }

    public PokemonStats Stats { get; set; }
    public PokemonStats EVs { get; set; }

    public List<PokemonType> Types { get; set; }
    
    /// <summary> When the type(s) of the pokemon has changed since its first appearance, this list will contains its previous types</summary>
    public List<PokemonType> PastTypes { get; set; }

    public List<PokemonMoveDetails> Moves { get; set; }
    public List<PokemonAbility> Abilities { get; set; }
    
    /// <summary> Item(s) the pokemon can hold when obtaining it. Contains the chance by version</summary>
    public List<PokemonHeldItemDetails> HeldItems { get; set; }

    internal PokemonDetails(PokemonJSON json)
    {
        Height = json.Height;
        Weight = json.Weight;
        BaseExperience = json.BaseExperience;

        #region Stats

        Stats = new();
        EVs = new();
        foreach (var stat in json.Stats)
        {
            if (stat.Name.Name == "hp")
            {
                Stats.HP = stat.BaseStat;
                EVs.HP = stat.Effort;
            }
            else if (stat.Name.Name == "attack")
            {
                Stats.Attack = stat.BaseStat;
                EVs.Attack = stat.Effort;
            }
            else if (stat.Name.Name == "defense")
            {
                Stats.Defense = stat.BaseStat;
                EVs.Defense = stat.Effort;
            }
            else if (stat.Name.Name == "special-attack")
            {
                Stats.SpecialAttack = stat.BaseStat;
                EVs.SpecialAttack = stat.Effort;
            }
            else if (stat.Name.Name == "special-defense")
            {
                Stats.SpecialDefense = stat.BaseStat;
                EVs.SpecialDefense = stat.Effort;
            }
            else if (stat.Name.Name == "speed")
            {
                Stats.Speed = stat.BaseStat;
                EVs.Speed = stat.Effort;
            }
        }

        #endregion

        json.Abilities.ForEach(a => Abilities.Add(new PokemonAbility(a)));
        json.Types.ForEach(t => Types.Add(t.Type.Name));
        json.PastTypes.ForEach(t => PastTypes.AddRange(t.Types.Select(tt => tt.Type.Name)));

        #region Version related data

        foreach (var move in json.Moves) 
        {
            var moveData = StaticData.Moves.FirstOrDefault(d => move.Name.Name == d.Name);
            if (moveData != null)
                Moves.Add(new PokemonMoveDetails(move, moveData));
        }

        foreach (var item in json.HeldItems)
        {
            var itemData = StaticData.Items.FirstOrDefault(i => item.Item.Name == i.Name);
            if (itemData != null)
                HeldItems.Add(new PokemonHeldItemDetails(item, itemData));
        }

        #endregion
    }
}

public class PokemonStats
{
    public int HP { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int SpecialAttack { get; set; }
    public int SpecialDefense { get; set; }
    public int Speed { get; set; }
}

public class PokemonMoveDetails
{
    public PokemonMoveModel Move { get; set; }
    public Dictionary<VersionGroup, PokemonMoveLearnDetails> LearnDetailsByVersion { get; set; }
    
    internal PokemonMoveDetails(MoveJSON moveJson, PokemonMoveModel moveModel)
    {
        Move = moveModel;
        LearnDetailsByVersion = moveJson.DataByVersionGroup.ToDictionary(
            d => d.VersionGroup.Name,
            d => new PokemonMoveLearnDetails
            {
                LearnAtLevel = d.LearnAtLevel,
                LearnMethod  = d.LearnMethod.Method
            }
        );
    }
}

public class PokemonMoveLearnDetails
{
    public MoveLearnMethod LearnMethod { get; set; }
    public int LearnAtLevel { get; set; }
}

public class PokemonAbility
{
    public int Id { get; set; }

    /// <summary> English name </summary>
    public string Name { get; set; }
    
    /// <summary> Short explanation of the ability, it's english only </summary>
    public string Explanation { get; set; }

    public bool IsHidden { get; set; }

    /// <summary> Key is the ISO lang, Value is the name of the ability </summary>
    public Dictionary<string, string> NameByLang { get; set; }

    /// <summary> Key is the ISO lang, Value is the description of the ability </summary>
    public Dictionary<string, string> DescriptionByLang { get; set; }

    internal PokemonAbility(AbilityJSON json)
    {
        IsHidden = json.IsHidden;

        if (int.TryParse(json.Name.Url.Replace("https://pokeapi.co/api/v2/ability/", "").Replace("/", ""), out var id)) 
        {
            Id = id;
            var ability = StaticData.Abilities.FirstOrDefault(a => a.Id == Id);
            if(ability != null) 
            { 
                Name                = ability.Name;
                Explanation         = ability.Explanation;
                NameByLang          = ability.NameByLang;
                DescriptionByLang   = ability.DescriptionByLang;
            }
        } 
        else Name = json.Name.Name;
    }
}

public class PokemonHeldItemDetails
{
    public PokemonItemModel Item { get; set; }
    public Dictionary<PokemonVersion, int> RarityByVersion { get; set; }

    internal PokemonHeldItemDetails(HeldItemJSON itemJson, PokemonItemModel itemModel)
    {
        Item = itemModel;
        RarityByVersion = itemJson.DetailByVersion.ToDictionary(d => d.Version.Name, d => d.Rarity);
    }
}