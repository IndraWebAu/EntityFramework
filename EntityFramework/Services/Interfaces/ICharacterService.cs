using EntityFramework.DTOs;
using EntityFramework.Models;

namespace EntityFramework.Services.Interfaces;

    public interface ICharacterService
    {
    Task<List<Character>> CreateCharacter(CharacterCreateDto request);
    Task<List<Character>> GetCharacters();
    Task<List<Character>> GetCharacter(int id);
    Task<List<Character>> DeleteCharacter(int id);
    Task<List<Character>> UpdateCharacter(CharacterUpdateDto request);
}

