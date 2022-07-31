namespace Pokedex.Models;

public class PokemonModel
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    
    /// <summary> Key is lang ISO code, Value is the translated name </summary>
    public Dictionary<string, string> NameByLang { get; private set; }

    public bool IsCaught { get; set; }

    private PokemonDetails? _details { get; set; }
    public PokemonDetails? Details { get => LoadDetails(); }

    private List<PokemonEncounter> _encounters { get; set; }
    public List<PokemonEncounter> Encounters { get => LoadEncounters(); }

    public string Picture { get => $"{StaticResources.PokemonSprites}{Id}.png"; }
    public string ShinyPicture { get => $"{StaticResources.ShinySprites}{Id}.png"; }
    public string ShinyFemalePicture { get => $"{StaticResources.ShinyFemaleSprites}{Id}.png"; }
    public string FemalePicture { get => $"{StaticResources.FemaleSprites}{Id}.png"; }


    public PokemonDetails LoadDetails()
    {
        //if(_details == null)
        //{
        //    var detailsFile = File.ReadAllText($"{StaticResources.PokemonDetails}{Id} ({Name}).json");
        //    _details = JsonSerializer.Deserialize<PokemonJSON>(detailsFile);
        //}
        return _details;
    }

    public List<PokemonEncounter> LoadEncounters()
    {
        //if (_encounters == null)
        //{
        //    var encounterFile = File.ReadAllText($"{StaticResources.PokemonDetails}{Id} ({Name})-encounters.json");
        //    _encounters = JsonSerializer.Deserialize<EncounterJSON>(encounterFile);
        //}
        return _encounters;
    }

    internal PokemonModel(PokemonJSON json, List<EncounterJSON> encountersJson = null)
    {
        Id = json.Id;
        Name = json.Name;

        // Uncomment when implemented in StaticData
        //NameByLang = StaticData.PokemonsNames.FirstOrDefault(p => p.Id == Id);

        _details = new PokemonDetails(json);

        if (encountersJson != null)
            foreach(var encounter in encountersJson)
                foreach (var version in encounter.VersionDetails)
                    _encounters.Add(new PokemonEncounter
                    {
                        Version = version.Version.Name,
                        MaxChance = version.MaxChance,
                        MaximumLevel = version.Details.Max(d => d.MaxLevel),
                        MinimumLevel = version.Details.Min(d => d.MinLevel),
                        ChanceByLevel = version.Details.Select(d => new ChanceByLevel
                        {
                            Chance          = d.Chance,
                            Conditions      = d.Conditions.Select(c => c.Name).ToList(),
                            EncounterMethod = d.Method.Name,
                            MaximumLevel    = d.MaxLevel,
                            MinimumLevel    = d.MinLevel
                        }).ToList()
                    });
    }
}
