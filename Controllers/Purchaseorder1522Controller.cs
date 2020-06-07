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
    [Route("purchase")]
    [ApiController]
    public class Purchaseorder1522Controller : ControllerBase
    {
        private readonly _102661522Context _context;

        public Purchaseorder1522Controller(_102661522Context context)
        {
            _context = context;
        }

        // GET: api/Purchaseorder1522
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Purchaseorder1522>>> GetPurchaseorder1522()
        {
            return await _context.Purchaseorder1522.ToListAsync();
        }




        // POST: api/Purchaseorder1522
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        [HttpPost]
        public async Task<ActionResult<Purchaseorder1522>> PostPurchaseorder1522(Purchaseorder1522 p)
        {
            try
            {
                await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC PURCHASE_STOCK @PPRODID = {p.Productid}, @PLOCID = {p.Locationid}, @PQTY = {p.Quantity}");
            }
            catch (DbUpdateException)
            {
                if (Purchaseorder1522Exists(p.Productid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPurchaseorder1522", new { id = p.Productid }, p);
        }



        private bool Purchaseorder1522Exists(int id)
        {
            return _context.Purchaseorder1522.Any(e => e.Productid == id);
        }
    }
}
