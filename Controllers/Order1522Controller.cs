using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TSQL_WEB_API.Models;

namespace TSQL_WEB_API.Controllers
{
    [Route("order")]
    [ApiController]
    public class Order1522Controller : ControllerBase
    {
        private readonly _102661522Context _context;

        public Order1522Controller(_102661522Context context)
        {
            _context = context;
        }

        // GET: api/Order1522
        [HttpGet]
        public async Task<ActionResult<List<Order1522>>> GetOrder1522()
        {

            return await _context.Order1522.FromSqlRaw("EXEC GET_OPEN_ORDERS").ToListAsync();
        }

        // GET: api/Order1522/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Order1522Custom>>> GetOrder1522(int id)
        {
            try
            {
                SqlParameter p1 = new SqlParameter("@PORDERID", id);

                return await _context.Order1522Custom.FromSqlRaw("EXEC GET_ORDER_BY_ID @PORDERID", p1).ToListAsync();

            }
            catch
            {
                return NotFound("ORDER DOES NOT EXIST");
            }
        }

        // PUT: api/Order1522/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        [HttpPut]
        public async Task<IActionResult> PutOrder1522(Order1522 o)
        {
            try
            {
                await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC FULLFILL_ORDER @PORDERID = {o.Orderid}");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Order1522Exists(o.Orderid))
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

        // POST: api/Order1522
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        [HttpPost]
        public async Task<ActionResult<Order1522>> PostOrder1522(Order1522 o)
        {
            try
            {
                await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC CREATE_ORDER @PSHIPPINGADDRESS = {o.Shippingaddress}, @PUSERID = {o.Userid}");
            }
            catch (DbUpdateException)
            {
                if (Order1522Exists(o.Orderid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction("GetOrder1522", new { id = o.Orderid }, o);
        }       

        private bool Order1522Exists(int id)
        {
            return _context.Order1522.Any(e => e.Orderid == id);
        }
    }
}
