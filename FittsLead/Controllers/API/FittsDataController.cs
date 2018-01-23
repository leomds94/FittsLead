using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FittsLead.Models;
using FittsLead.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FittsLead.Controllers.API
{
    [Route("api/[controller]")]
    public class FittsDataController : Controller
    {
        private readonly FittsDbContext _fittsDbContext;

        public FittsDataController(FittsDbContext fittsDbContext)
        {
            _fittsDbContext = fittsDbContext;
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]FittsUser FittsUser)
        {
            _fittsDbContext.Add(FittsUser);
            await _fittsDbContext.SaveChangesAsync();
            return Json(FittsUser.UserId);
        }
    }
}
