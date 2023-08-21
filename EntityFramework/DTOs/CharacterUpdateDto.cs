namespace EntityFramework.DTOs
{
    public record struct CharacterUpdateDto(
        int id,
        string Name,
        BackpackCreateDto Backpack,
        List<WeaponCreateDto> Weapons,
        List<FactionCreateDto> Factions);
}
