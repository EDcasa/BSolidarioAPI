using BSolidarioAPI.Data;
using BSolidarioAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BSolidarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public ClientController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            var listCLients = await _db.Clients.OrderBy(c => c.last_name).ToListAsync();
            return Ok(listCLients);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetClient(int id)
        {
            var objClient= await _db.Clients.FirstOrDefaultAsync(c => c.Id == id);
            if (objClient == null)
            {
                return NotFound();
            }
            return Ok(objClient);
            
        }

        [HttpPost]
        public async Task<IActionResult> RegisterClient([FromBody] Client client)
        {
            if (client == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _db.AddAsync(client);
            await _db.SaveChangesAsync();

            return Ok();
        }
    }
}
