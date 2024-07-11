using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IceCreamStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using IceCreamStore.Data;

namespace IceCreamStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlavourController : ControllerBase
    {
        private readonly IceCreamContext newContext;

        public FlavourController(IceCreamContext context) {
            newContext = context;
        }
         [HttpGet]
        public async Task<ActionResult<IEnumerable<Flavour>>> GetFlavors([FromQuery] string type)
        {
            if (string.IsNullOrEmpty(type))
            {
                return BadRequest("Type is required");
            }

            var flavors = await newContext.Flavours.Where(f => f.Type == type).ToListAsync();
            return Ok(flavors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Flavour>> GetFlavor(int id)
        {
            var flavor = await newContext.Flavours.FindAsync(id);

            if (flavor == null)
            {
                return NotFound();
            }

            return flavor;
        }
    }
}