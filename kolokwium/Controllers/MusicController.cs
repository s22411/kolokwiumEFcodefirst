using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace kolokwium.Controllers
{
    [Route("[controller]")]
    public class MusicController : ControllerBase
    {
        private readonly  _context;
    }
}