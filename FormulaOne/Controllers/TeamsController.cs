using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulaOne.Data;
using FormulaOne.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FormulaOne.Controllers
{
    [Route(template:"api/[controller]")]
    [ApiController]
    public class TeamsController : Controller
    {
        private static AppDbContext _context;

        public TeamsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var teams = await _context.teams.ToListAsync();

            return Ok(teams);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var team = await _context.teams.FirstOrDefaultAsync(x => x.Id == id);

            if (team == null)
                return BadRequest("Invalid Id");

            return Ok(team);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Team team)
        { 
            await _context.teams.AddAsync(team);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", team.Id, team);
        }

        [HttpPatch]
        public async Task<IActionResult> Patch(int id, string country)
        {
            var team = await _context.teams.FirstOrDefaultAsync(x => x.Id == id);

            if (team == null)
                return BadRequest("invalid id");

            team.Country = country;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var team = await _context.teams.FirstOrDefaultAsync(x => x.Id == id);

            if (team == null)
                return BadRequest("invalid id");

            _context.teams.Remove(team);
            await _context.SaveChangesAsync();


            return NoContent();
        }

    }
}

