using Microsoft.AspNetCore.Mvc;
using Core;
using System.Collections.Generic;

namespace ApiTattoo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : Controller
    {
        [HttpGet]
        public IEnumerable<Request> Get()
        {
            return DataAccess.GetRequests();
        }

        [HttpGet("{idRequest}")]
        public ActionResult<Request> Get(int idRequest)
        {
            var result = DataAccess.GetRequest(idRequest);
            if (result == null)
                return NotFound();

            return result;
        }

        [HttpPost]
        public IActionResult Create(Request request)
        {
            DataAccess.AddNewRequest(request);
            return CreatedAtAction(nameof(Create), request);
        }

        [HttpPut("{idRequest}")]
        public IActionResult Update(int idRequest, Request request)
        {
            var result = DataAccess.GetRequest(idRequest);
            if (result == null)
                return NotFound();

            DataAccess.UpdtaeRequest(request);

            return NoContent();
        }

        [HttpDelete("{idRequest}")]
        public IActionResult Delete(int idRequest)
        {
            var result = DataAccess.GetRequest(idRequest);
            if (result == null)
                return NotFound();

            DataAccess.DeleteRequest(idRequest);
            return NoContent();
        }
    }
}
