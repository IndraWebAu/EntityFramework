using System.Text.Json.Serialization;

namespace EntityFramework.Models
{
    public class Faction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CharacterId { get; set; }

        [JsonIgnore]
        public List<Character> Characters { get; set; }
    }
}


/*

This is a Child of the Character.

Note it has a CharacterId. This is because a Character can belong to a Faction.

Many Characters can belong to a Faction

therefore it requires a List of Characters.
  
*/ 