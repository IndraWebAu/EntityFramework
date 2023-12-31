﻿using EntityFramework.DTOs;
using EntityFramework.Models;
using EntityFramework.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Characters : ControllerBase
    {
        private readonly ICharacterService _characterService;


        // Inject the service that performs the EF work to save the Character
        public Characters(ICharacterService characterService) =>
                                this._characterService = characterService;

        [HttpPost]
        public async Task<ActionResult<List<Character>>>
            CreateCharacter(CharacterCreateDto request) =>
                        Ok(await _characterService.CreateCharacter(request));

        [HttpGet]
        public async Task<ActionResult<List<Character>>>
            GetCharacters() =>
                Ok(await _characterService.GetCharacters());

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Character>>> GetCharacter(int id)
        {
            try
            {
                return Ok(await _characterService.GetCharacter(id));

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCharacter(int id)
        {
            try
            {
                return Ok(await _characterService.DeleteCharacter(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCharacter(CharacterUpdateDto request)
        {
            try
            {
                return Ok(await _characterService.UpdateCharacter(request));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
    }
}


/*
 
Inject the Service that does the EF work of saving the Model to the DB.

Pass in a DTO. This will be used to populate the EF DAta Model.

Note the EF work is hidden behind the Service.

 */
