using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Data;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly DataContext _context;
        public SuperHeroController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            try
            {
                return Ok(await _context.SuperHeroes.ToListAsync());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<SuperHero>>> Get(int id)
        {
            try
            {
                var hero = await _context.SuperHeroes.FindAsync(id);
                if (hero == null)
                    return BadRequest("Hero not found.");
                return Ok(hero);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            try
            {
                _context.SuperHeroes.Add(hero);
                await _context.SaveChangesAsync();
                return Ok(await _context.SuperHeroes.ToListAsync());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request)
        {
            try
            {
                var dbHero = await _context.SuperHeroes.FindAsync(request.Id);
                if (dbHero == null)
                    return BadRequest("Hero not found.");
                dbHero.Name = request.Name;
                dbHero.FirstName = request.FirstName;
                dbHero.LastName = request.LastName;
                dbHero.Place = request.Place;

                await _context.SaveChangesAsync();
                return Ok(await _context.SuperHeroes.ToListAsync());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> Delete(int id)
        {
            try
            {
                var dbHero = await _context.SuperHeroes.FindAsync(id);
                if (dbHero == null)
                    return BadRequest("Hero not found.");
                _context.SuperHeroes.Remove(dbHero);
                await _context.SaveChangesAsync();
                return Ok(await _context.SuperHeroes.ToArrayAsync());
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
