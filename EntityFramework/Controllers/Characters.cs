using EntityFramework.Data;
using EntityFramework.DTOs;
using EntityFramework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Characters : ControllerBase
    {
        private readonly DataContext _context;

        public Characters(DataContext context)
        {
            this._context = context;
        }

        [HttpPost]
        public async Task<ActionResult<List<Character>>> CreateCharacter(CharaterCreateDto request)
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

            await _context.SaveChangesAsync();

            return Ok(await _context.Characters.Include(c => c.Backpack).ToListAsync());
        }
    }
}
