using EntityFramework.Data;
using EntityFramework.DTOs;
using EntityFramework.Models;
using EntityFramework.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Services.Implementations;
public class CharacterService : ICharacterService
{
    private readonly DataContext _context;

    public CharacterService(DataContext context)
    {
        this._context = context;
    }
    public async Task<List<Character>> CreateCharacter(CharaterCreateDto request)
    {
        // This is the EF Model. Populate it with the DTO Request
        var newCharacter = new Character
        {
            Name = request.Name
        };

        // One to One.
        // One Character can only have One Backpack
        // One Backpack can only be owned by One Character
        var backpack = new Backpack
        {
            Description = request.Backpack.Description,
            Character = newCharacter  // Note One Character related to the Backpack
        };

        newCharacter.Backpack = backpack;

        // One to Many.
        // One Character can have Many Weapons.
        // One Weapon can only be owned by One Character.

        var weapons = request
                        .Weapons // Note Many Weapons for One Character
                        .Select(w => new Weapon
                        {
                            Name = w.Name,
                            Character = newCharacter // Note One Character related to the Weapon.
                        })
                        .ToList();

        newCharacter.Weapons = weapons;

        // Many to Many.
        // One Character can belong to Many Factions.
        // One Faction can have Many characters in it.

        var factions = request
            .Factions // Note Many Factions for One Character
            .Select(f => new Faction
            {
                Name = f.Name,
                Characters = new List<Character> { newCharacter } // Note Many Characters related to the Faction
            })
            .ToList();

        newCharacter.Factions = factions;

        _context.Characters.Add(newCharacter);

        await _context.SaveChangesAsync();

        return await _context
                        .Characters
                        .Include(c => c.Backpack)
                        .Include(c => c.Weapons)
                        .Include(c => c.Factions)
                        .ToListAsync();
    }
}


/* 
 
This is the service that the API calls to create a Character.

It takes a DTO as the request and populates the EF Model with it.

It injects the DataContext as a service and uses it to save the EF model to the DB.

One Character can have one Backpack
therefore populate new backpack and assign to Character. Include character in Backpack,

One Character can have many Weapons, therefore query the list of Weapons.
One Weapon can only have one Owner, therefore assing Character to it.

One Character can belong to Many Factions, therefore query the list of Factions.
One Faction can have Many Characters, therefore assing the Character to a List as a List.
 
 */

