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
    [Route("payment")]
    [ApiController]
    public class Accountpayment1522Controller : ControllerBase
    {
        private readonly _102661522Context _context;

        public Accountpayment1522Controller(_102661522Context context)
        {
            _context = context;
        }

        // GET: api/Accountpayment1522
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Accountpayment1522>>> GetAccountpayment1522()
        {
            return await _context.Accountpayment1522.ToListAsync();
        }
             
        // POST: api/Accountpayment1522
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        [HttpPost]
        public async Task<ActionResult<Accountpayment1522>> PostAccountpayment1522(Accountpayment1522 a)
        {
            try
            {
                await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC MAKE_ACCOUNT_PAYMENT @PACCOUNTID = {a.Accountid}, @PAMOUNT = {a.Amount}");
            }
            catch (DbUpdateException)
            {
                if (Accountpayment1522Exists(a.Accountid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAccountpayment1522", new { id = a.Accountid }, a);
        }        
        private bool Accountpayment1522Exists(int id)
        {
            return _context.Accountpayment1522.Any(e => e.Accountid == id);
        }
    }
}
