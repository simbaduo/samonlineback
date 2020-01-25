using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using samonlineback.Models;

namespace samonlineback.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarSalesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public CarSalesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/CarSales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarSales>>> GetCarSales()
        {
            return await _context.CarSales.ToListAsync();
        }

        // GET: api/CarSales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarSales>> GetCarSales(int id)
        {
            var carSales = await _context.CarSales.FindAsync(id);

            if (carSales == null)
            {
                return NotFound();
            }

            return carSales;
        }

        // PUT: api/CarSales/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarSales(int id, CarSales carSales)
        {
            if (id != carSales.Id)
            {
                return BadRequest();
            }

            _context.Entry(carSales).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarSalesExists(id))
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

        // POST: api/CarSales
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<CarSales>> PostCarSales(CarSales carSales)
        {
            _context.CarSales.Add(carSales);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarSales", new { id = carSales.Id }, carSales);
        }

        // DELETE: api/CarSales/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CarSales>> DeleteCarSales(int id)
        {
            var carSales = await _context.CarSales.FindAsync(id);
            if (carSales == null)
            {
                return NotFound();
            }

            _context.CarSales.Remove(carSales);
            await _context.SaveChangesAsync();

            return carSales;
        }

        private bool CarSalesExists(int id)
        {
            return _context.CarSales.Any(e => e.Id == id);
        }
    }
}
