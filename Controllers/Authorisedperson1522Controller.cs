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
    [Route("authorisedperson")]
    [ApiController]
    public class Authorisedperson1522Controller : ControllerBase
    {
        private readonly _102661522Context _context;

        public Authorisedperson1522Controller(_102661522Context context)
        {
            _context = context;
        }

        // GET: api/Authorisedperson1522
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Authorisedperson1522>>> GetAuthorisedperson1522()
        {
            return await _context.Authorisedperson1522.ToListAsync();
        }

        // POST: api/Authorisedperson1522
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Authorisedperson1522>> PostAuthorisedperson1522(Authorisedperson1522 a)
        {
            try
            {

                

                await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC ADD_AUTHORISED_PERSON @PFIRSTNAME = {a.Firstname}, @PSURNAME = {a.Surname}, @PEMAIL = {a.Email},@PPASSWORD = {a.Password}, @PACCOUNTID = {a.Accountid}");
            }
            catch (DbUpdateException)
            {
                if (Authorisedperson1522Exists(a.Userid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAuthorisedperson1522", new { id = a.Userid }, a);
        }
       
        private bool Authorisedperson1522Exists(int id)
        {
            return _context.Authorisedperson1522.Any(e => e.Userid == id);
        }
    }
}
