namespace Pokedex.Models;

/// <summary> Represent the data of an Item without context (Pkmn, Version, ...). It take a context when construct using <see cref="PokemonHeldItemDetails"/></summary>
public class PokemonItemModel
{
    public int Id { get; set; }

    /// <summary> English name </summary>
    public string Name { get; set; }

    /// <summary> Short explanation of the item effect, it's english only </summary>
    public string Explanation { get; set; }

    /// <summary> Key is the ISO lang, Value is the name of the item </summary>
    public Dictionary<string, string> NameByLang { get; set; }

    /// <summary> Key is the ISO lang, Value is the description of the item </summary>
    public Dictionary<string, string> DesciptionByLang { get; set; }

    public string Picture { get => $"{StaticResources.ItemSprites}{Name}.png"; }

    //internal PokemonItem(HeldItemJSON json)
    //{
    //    json.DetailByVersion.ForEach(v => RarityByVersion.Add(v.Version.Name, v.Rarity));

    //    if (int.TryParse(json.Item.Url.Replace("https://pokeapi.co/api/v2/item/", "").Replace("/", ""), out var id))
    //    {
    //        Id = id;
    //        var item = StaticData.Items.FirstOrDefault(i => i.Id == Id);
    //        if (item != null)
    //        {
    //            Name                = item.Name;
    //            Explanation         = item.Explanation;
    //            NameByLang          = item.NameByLang;
    //            DescriptionByLang   = item.DescriptionByLang;
    //        }
    //    }
    //    else Name = json.Item.Name;
    //}
}
