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
    public class ClientPlanTypeController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public ClientPlanTypeController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetClientPlanType()
        {
            var listCLients = await _db.ClientPlanTypes.OrderBy(c => c.PlanTypeId).ToListAsync();
            return Ok(listCLients);
        }

        [HttpGet("{clientId:int}")]
        public async Task<IActionResult> GetClientPlanTypeByClient(int clientId)
        {
            var objClient = await _db.ClientPlanTypes.FirstOrDefaultAsync(c => c.ClientId == clientId);
            if (objClient == null)
            {
                return NotFound();
            }
            return Ok(objClient);

        }

        [HttpPost]
        public async Task<IActionResult> RegisterPlanType([FromBody] ClientPlanType ClientPlanType)
        {
            if (ClientPlanType  == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _db.AddAsync(ClientPlanType);
            await _db.SaveChangesAsync();

            return Ok();
        }

    }
}
