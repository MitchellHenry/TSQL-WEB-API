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
    [Route("account")]
    [ApiController]
    public class Clientaccount1522Controller : ControllerBase
    {
        private readonly _102661522Context _context;

        public Clientaccount1522Controller(_102661522Context context)
        {
            _context = context;
        }

        // GET: api/Clientaccount1522
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clientaccount1522>>> GetClientaccount1522()
        {
            return await _context.Clientaccount1522.ToListAsync();
        }

        // GET: api/Clientaccount1522/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Clientaccount1522Custom>>> GetClientaccount1522(int id)
        {
            SqlParameter p1 = new SqlParameter("@PACCOUNTID", id);

            return await _context.Clientaccount1522Custom.FromSqlRaw("EXEC GET_CLIENT_ACCOUNT_BY_ID  @PACCOUNTID", p1).ToListAsync();
            // var account = await Task.FromResult(_context.Clientaccount1522.Include(x => x.Authorisedperson1522).ToList());
            // return account;

        }

        // POST: api/Clientaccount1522
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        [HttpPost]
        public async Task<ActionResult<Clientaccount1522>> PostClientaccount1522(Clientaccount1522 c)
        {
            try
            {
                await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC ADD_CLIENT_ACCOUNT @PACCTNAME = {c.Acctname}, @PBALANCE = {c.Balance}, @PCREDITLIMIT = {c.Creditlimit}");
            }
            catch (DbUpdateException)
            {
                if (Clientaccount1522Exists(c.Accountid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetClientaccount1522", new { id = c.Accountid }, c);
        }



        private bool Clientaccount1522Exists(int id)
        {
            return _context.Clientaccount1522.Any(e => e.Accountid == id);
        }
    }
}
