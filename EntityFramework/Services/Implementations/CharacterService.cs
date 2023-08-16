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
    public Task<List<Character>> CreateCharacter(CharaterCreateDto request)
    {
        var newCharacter = new Character
        {
            Name = request.Name
        };

        var backpack = new Backpack
        {
            Description = request.Backpack.Description,
            Character = newCharacter
        };

        newCharacter.Backpack = backpack;

        _context.Characters.Add(newCharacter);

        _context.SaveChangesAsync();

        return _context.Characters.Include(c => c.Backpack).ToListAsync();
    }
}

