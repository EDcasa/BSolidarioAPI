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
    public class PlanTypeController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public PlanTypeController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlanType()
        {
            var listCLients = await _db.PlanType.OrderBy(c => c.Name).ToListAsync();
            return Ok(listCLients);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPlanTypeById(int id)
        {
            var objClient = await _db.PlanType.FirstOrDefaultAsync(c => c.Id == id);
            if (objClient == null)
            {
                return NotFound();
            }
            return Ok(objClient);

        }

        [HttpPost]
        public async Task<IActionResult> RegisterPlanType([FromBody] PlanType planType)
        {
            if (planType == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _db.AddAsync(planType);
            await _db.SaveChangesAsync();

            return Ok();
        }


    }
}
