using EntityFramework.DTOs;
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
            CreateCharacter(CharaterCreateDto request) =>
                        Ok(await _characterService.CreateCharacter(request));
    }
}

/*
 
Inject the Service that does the EF work of saving the Model to the DB.

Pass in a DTO. This will be used to populate the EF DAta Model.

Note the EF work is hidden behind the Service.

 */
