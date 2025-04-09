using CasinoProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Casino.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Casino : ControllerBase
    {
        private readonly CasinoContext _context = new();

        [HttpGet("/api/players/number")]
        public async Task<IActionResult> GetAllPlayer()
        {

            return Ok(await _context.Players.CountAsync());
        }
        [HttpGet("/api/players/amount/1000")]
        public async Task<IActionResult> GetTheRichOne()
        { 
            return Ok(await _context.Players.CountAsync(p => p.Play >= 1000));
        }
        [HttpGet("/api/games/sort")]
        public async Task<IActionResult> GetAmountDesc()
        {
            return Ok(await _context.Players.OrderByDescending(p => p.Play).ToListAsync());
        }
        [HttpGet("/api/games/player/3")]
        public async Task<IActionResult> GetOnlyTheThird()
        {
            return Ok(await _context.Players.Where(p=>p.Games==3));
        }

        [HttpGet("/api/players/12")]
        public async Task<IActionResult>Delete12()
        {
            return Ok(await _context.Players.Where(p => p.Player.id == 12).ToDelete());
        }
    }
}
