using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TSQL_WEB_API.Models;

namespace TSQL_WEB_API.Controllers
{
    [Route("orderline")]
    [ApiController]
    public class Orderline1522Controller : ControllerBase
    {
        private readonly _102661522Context _context;

        public Orderline1522Controller(_102661522Context context)
        {
            _context = context;
        }

        // GET: api/Orderline1522
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orderline1522>>> GetOrderline1522()
        {
            return await _context.Orderline1522.ToListAsync();
        }
              
        // POST: api/Orderline1522
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        [HttpPost]
        public async Task<ActionResult<Orderline1522>> PostOrderline1522(Orderline1522 o)
        {
            try
            {
                await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC ADD_PRODUCT_TO_ORDER @PORDERID = {o.Orderid}, @PPRODID = {o.Productid}, @PQTY = {o.Quantity}, @DISCOUNT = {o.Discount}");
            }
            catch (DbUpdateException)
            {
                if (Orderline1522Exists(o.Orderid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOrderline1522", new { id = o.Orderid }, o);
        }

       // DELETE: api/Orderline1522
        [HttpDelete]
        public async Task<ActionResult<Orderline1522>> DeleteOrderline1522(Orderline1522 o)
        {
            try
            {
                await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC REMOVE_PRODUCT_FROM_ORDER @PORDERID = {o.Orderid}, @PPRODID = {o.Productid}");
            }
            catch (DbUpdateException)
            {
                if (Orderline1522Exists(o.Orderid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        private bool Orderline1522Exists(int id)
        {
            return _context.Orderline1522.Any(e => e.Orderid == id);
        }
    }
}
