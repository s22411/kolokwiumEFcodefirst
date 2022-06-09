using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kolokwium.Models;
using kolokwium.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kolokwium.Controllers
{
    [Route("[controller]")]
    public class MusicController : ControllerBase
    {
        private readonly MainDbContext _context;

        public MusicController(MainDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("albums/{id}")]
        public async Task<IActionResult> GetMusician(int id)
        {
            var musician = await _context.Musicians.Where(m => m.IdMusician == id).Select(m => new GetMusicianDTO
            {
                Musician = m,
                Tracks = m.Musician_Tracks.Join(_context.Tracks, mt => mt.IdTrack, t => t.IdTrack, (mt, t) => t).ToList()
            }).FirstOrDefaultAsync();
            
            
            if (musician == null)
            {
                return NotFound("No musician with this id");
            }


            return Ok(musician);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMusician(int id)
        {
            var musician = await _context.Musicians.Where(m => m.IdMusician == id).FirstOrDefaultAsync();
            if (musician == null)
            {
                return NotFound("No musician with this id");
            }


            if (musician.Musician_Tracks is null)
            {

            
                var tracks = await _context.Musician_Tracks.Join(_context.Tracks, mt => mt.IdTrack, t => t.IdTrack, (mt, t) => new { mt, t }).Where(t => t.t.IdMusicAlbum != null).ToListAsync();

                if (tracks.Count > 0)
                {
                    return BadRequest("Musician is in album");
                }
            }

            _context.Musicians.Remove(musician);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}