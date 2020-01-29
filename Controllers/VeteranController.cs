using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AuthExample.Models;
using samonlineback.Models;

namespace samonlineback.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class VeteranController : ControllerBase
  {
    private readonly DatabaseContext _context;

    public VeteranController(DatabaseContext context)
    {
      _context = context;
    }

    // GET: api/Veteran
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Veteran>>> GetVeteran()
    {
      return await _context.Veteran.ToListAsync();
    }

    // GET: api/Veteran/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Veteran>> GetVeteran(int id)
    {
      var veteran = await _context.Veteran.FindAsync(id);

      if (veteran == null)
      {
        return NotFound();
      }

      return veteran;
    }

    // PUT: api/Veteran/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see https://aka.ms/RazorPagesCRUD.
    [HttpPut("{id}")]
    public async Task<IActionResult> PutVeteran(int id, Veteran veteran)
    {
      if (id != veteran.Id)
      {
        return BadRequest();
      }

      _context.Entry(veteran).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!VeteranExists(id))
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

    // POST: api/Veteran
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see https://aka.ms/RazorPagesCRUD.
    [HttpPost]
    public async Task<ActionResult<Veteran>> PostVeteran(Veteran veteran)
    {
      _context.Veteran.Add(veteran);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetVeteran", new { id = veteran.Id }, veteran);
    }

    // DELETE: api/Veteran/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Veteran>> DeleteVeteran(int id)
    {
      var veteran = await _context.Veteran.FindAsync(id);
      if (veteran == null)
      {
        return NotFound();
      }

      _context.Veteran.Remove(veteran);
      await _context.SaveChangesAsync();

      return veteran;
    }

    private bool VeteranExists(int id)
    {
      return _context.Veteran.Any(e => e.Id == id);
    }
  }
}
