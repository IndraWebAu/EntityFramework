namespace EntityFramework.DTOs;

public record struct CharaterCreateDto(
    string Name,
    BackpackCreateDto Backpack,
    List<WeaponCreateDto> Weapons,
    List<FactionCreateDto> Factions
    );

/*
 
This is the topmost Data Transfer Object. DTO

It is used one as an argument to the Service

It contains all the data in the request

It is used to populate the EF Data Model sent to the EF layer.

It is comprised of child DTo's.

A record struct will suffice. No Class is neccessary.
  
 */