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
    [Route("product")]
    [ApiController]
    public class Product1522Controller : ControllerBase
    {
        private readonly _102661522Context _context;

        public Product1522Controller(_102661522Context context)
        {
            _context = context;
        }

        // GET: api/Product1522
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product1522>>> GetProduct1522()
        {
            return await _context.Product1522.ToListAsync();
        }

        // GET: api/Product1522/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Product1522>>> GetProduct1522(int id)
        {
            try
            {
                SqlParameter p1 = new SqlParameter("@PPRODID", id);

                return await _context.Product1522.FromSqlRaw("EXEC GET_PRODUCT_BY_ID @PPRODID", p1).ToListAsync();

            }
            catch
            {
                return NotFound("PRODUCT DOES NOT EXIST");
            }
        }


        // POST: api/Product1522
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        [HttpPost]
        public async Task<ActionResult<Product1522>> PostProduct1522(Product1522 p)
        {
            try
            {

                await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC ADD_PRODUCT @PPRODNAME = {p.Prodname}, @PBUYPRICE = {p.Buyprice}, @PSELLPRICE = {p.Sellprice}");

            }
            catch (DbUpdateException)
            {
                if (Product1522Exists(p.Productid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProduct1522", new { id = p.Productid }, p);
        }
        private bool Product1522Exists(int id)
        {
            return _context.Product1522.Any(e => e.Productid == id);
        }

    }
}