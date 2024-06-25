using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CMSWebAppLab2.Data;
using CMSWebAppLab2.Models;

namespace CMSWebAppLab2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsToMoviesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PersonsToMoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PersonsToMovies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonsToMovie>>> GetPersonsToMovies()
        {
            return await _context.PersonsToMovies.ToListAsync();
        }

        // GET: api/PersonsToMovies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonsToMovie>> GetPersonsToMovie(int id)
        {
            var personsToMovie = await _context.PersonsToMovies.FindAsync(id);

            if (personsToMovie == null)
            {
                return NotFound();
            }

            return personsToMovie;
        }

        // PUT: api/PersonsToMovies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonsToMovie(int id, PersonsToMovie personsToMovie)
        {
            if (id != personsToMovie.Id)
            {
                return BadRequest();
            }

            _context.Entry(personsToMovie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonsToMovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PersonsToMovies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PersonsToMovie>> PostPersonsToMovie(PersonsToMovie personsToMovie)
        {
            _context.PersonsToMovies.Add(personsToMovie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonsToMovie", new { id = personsToMovie.Id }, personsToMovie);
        }

        // DELETE: api/PersonsToMovies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonsToMovie(int id)
        {
            var personsToMovie = await _context.PersonsToMovies.FindAsync(id);
            if (personsToMovie == null)
            {
                return NotFound();
            }

            _context.PersonsToMovies.Remove(personsToMovie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonsToMovieExists(int id)
        {
            return _context.PersonsToMovies.Any(e => e.Id == id);
        }
    }
}
