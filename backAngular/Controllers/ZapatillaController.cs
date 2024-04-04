using backAngular.Data;
using backAngular.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZapatillaController : ControllerBase
    {

        private readonly DataContext _context;

        // Constructor
        public ZapatillaController(DataContext context)
        {
            _context = context;
        }

        // GET: api/<ZapatillaController> /1
        [HttpGet]
        public async Task<ActionResult<List<Zapatilla>>> GetAllSneakers()
        {
            var sneakers = await _context.Zapatillas.ToListAsync();

            return Ok(sneakers);
        }

        // GET: api/<ZapatillaController> /2
        [HttpGet("{id}")]
        public async Task<ActionResult<Zapatilla>> GetSneakerById(int id)
        {
            var sneaker = await _context.Zapatillas.FindAsync(id);
            if (sneaker == null)
            {
                return NotFound("Producto no encontrado");
            }

            return Ok(sneaker);
        }

        //// POST api/<ZapatillaController> /3
        [HttpPost]
        public async Task<ActionResult<List<Zapatilla>>> AddSneaker(Zapatilla sneaker)
        {
            _context.Zapatillas.Add(sneaker);
            await _context.SaveChangesAsync();

            return Ok(await _context.Zapatillas.ToListAsync());
        }

        //PUT api/<ZapatillaController>/4
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Zapatilla>>> UpdateSneaker(int id, Zapatilla zapatilla)
        {
            var sneaker = await _context.Zapatillas.FindAsync(id);
            if (sneaker == null)
            {
                return BadRequest("No existe ese producto");
            }

            sneaker.Product = zapatilla.Product;
            sneaker.Location = zapatilla.Location;
            sneaker.Stock = zapatilla.Stock;
            sneaker.Price = zapatilla.Price;
            sneaker.Img = zapatilla.Img;
            sneaker.Url = zapatilla.Url;

            await _context.SaveChangesAsync();

            return Ok(sneaker);
        }

        // DELETE api/<ZapatillaController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Zapatilla>> RemoveSneacker(int id)
        {
            var sneaker = await _context.Zapatillas.FindAsync(id);
            if (sneaker == null)
            {
                return NotFound("Producto no encontrado");
            }

            _context.Zapatillas.Remove(sneaker);
            await _context.SaveChangesAsync();

            return Ok(await _context.Zapatillas.ToListAsync());
        }
    }
}
