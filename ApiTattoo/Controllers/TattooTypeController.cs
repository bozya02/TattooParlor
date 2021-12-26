using Microsoft.AspNetCore.Mvc;
using Core;
using System.Collections.Generic;

namespace ApiTattoo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TattooTypeController : Controller
    {
        [HttpGet]
        public IEnumerable<TattooType> Get()
        {
            return DataAccess.GetTattooTypes();
        }

        [HttpGet("{idBodyPart}")]
        public ActionResult<TattooType> Get(int idBodyPart)
        {
            var result = DataAccess.GetTattooType(idBodyPart);
            if (result == null)
                return NotFound();

            return result;
        }
    }
}
