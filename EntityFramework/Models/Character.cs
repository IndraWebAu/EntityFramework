namespace EntityFramework.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Backpack Backpack { get; set; }
        public List<Weapon> Weapons { get; set; }

        public List<Faction> Factions{ get; set; }
    }
}

/* 

This is the top most EF Model.
It is comprised of child models.

These are used to create the relational DB schema.

It is also used to perform CRUD operations to the DB

If the model has child models of a One to Many or Many to Many

they are represented as Lists.

1-1
A Character can only have One Backpack
A Backpack can only be owned by One Character

1-M
A Character can have One or Many Weapons
A Weapon can only be owned by One Character

M-M
A Character can be in One or Many Faction
A Faction can contain Many Characters

 */