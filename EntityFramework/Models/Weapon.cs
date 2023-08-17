using System.Text.Json.Serialization;

namespace EntityFramework.Models
{
    public class Weapon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CharacterId { get; set; }

        [JsonIgnore]
        public Character Character { get; set; }
    }
}

/*

This is a Child of the Character.

Note it has a CharacterId. This is because a Weapon can belong to a Character.

One Weapon can belong to only One Character 

therefore the Character is NOT a List.
  
*/
