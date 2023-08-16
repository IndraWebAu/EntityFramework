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

        public Characters(ICharacterService characterService)
        {
            this._characterService = characterService;
        }

        [HttpPost]
        public async Task<ActionResult<List<Character>>>
            CreateCharacter(CharaterCreateDto request) =>
                        Ok(await _characterService.CreateCharacter(request));
    }
}
