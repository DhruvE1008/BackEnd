using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IceCreamStore.Models;
using IceCreamStore.Data;
using System.Collections.Generic;

namespace IceCreamStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IceCreamContext newContext;

        public OrdersController(IceCreamContext context)
        {
            newContext = context;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(Order order)
        {
            newContext.Orders.Add(order);
            await newContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await newContext.Orders.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await newContext.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            newContext.Entry(order).State = EntityState.Modified;

            try
            {
                await newContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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
                [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await newContext.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            newContext.Orders.Remove(order);
            await newContext.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderExists(int id)
        {
            return newContext.Orders.Any(e => e.Id == id);
        }
    }
}
