using Microsoft.AspNetCore.Mvc;
using Core;
using System.Collections.Generic;

namespace ApiTattoo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BodyPartController : Controller
    {
        [HttpGet]
        public IEnumerable<BodyPart> Get()
        {
            return DataAccess.GetBodyParts();
        }

        [HttpGet("{idBodyPart}")]
        public ActionResult<BodyPart> Get(int idBodyPart)
        {
            var result = DataAccess.GetBodyPart(idBodyPart);
            if (result == null)
                return NotFound();

            return result;
        }
    }
}
