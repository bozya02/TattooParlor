using Microsoft.AspNetCore.Mvc;
using Core;
using System.Collections.Generic;

namespace ApiTattoo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TattooController : ControllerBase
    {
        
        [HttpGet]
        public IEnumerable<Tattoo> Get()
        {
            return DataAccess.GetTattoos();
        }

        [HttpGet("{idTattoo}")]
        public ActionResult<Tattoo> Get(int idTattoo)
        {
            var result = DataAccess.GetTattoo(idTattoo);
            if (result == null)
                return NotFound();

            return result;
        }

        [HttpPost]
        public IActionResult Create(Tattoo tattoo)
        {
            DataAccess.AddNewTattoo(tattoo);
            return NoContent();
        }
    }
}
