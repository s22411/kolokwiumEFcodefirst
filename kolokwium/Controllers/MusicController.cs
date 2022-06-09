using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kolokwium.Models;
using Microsoft.AspNetCore.Mvc;

namespace kolokwium.Controllers
{
    [Route("[controller]")]
    public class MusicController : ControllerBase
    {
        private readonly MainDbContext _context;

        public MusicController(MainDbContext context)
        {
            _context = context;
        }

        
    }
}