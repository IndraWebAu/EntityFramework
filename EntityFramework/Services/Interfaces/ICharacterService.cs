using EntityFramework.DTOs;
using EntityFramework.Models;

namespace EntityFramework.Services.Interfaces;

    public interface ICharacterService
    {
    Task<List<Character>> CreateCharacter(CharaterCreateDto request);
    Task<List<Character>> GetCharacters();
    Task<List<Character>> GetCharacter(int id);
}

