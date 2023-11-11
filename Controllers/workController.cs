using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using works.Services.Contract;
using works.Utilities;

namespace works.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class workController : ControllerBase
    {
        private readonly Iwork _Details;
        public workController(Iwork Details)
        {
            _Details = Details;
        }
        [HttpPost]

        public IActionResult postLoginDetails(Loginrequest request)
        {
            ResponseAPI<Loginrequest> response = new ResponseAPI<Loginrequest>();
            try
            {
                Loginrequest newDetails = _Details.AddToList(request);
                response = new ResponseAPI<Loginrequest>
                {
                    Status = true,
                    Msg = "Added",
                    Value = newDetails
                };
                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                response = new ResponseAPI<Loginrequest>(); response.Msg = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
        [HttpPost("verify")]
        public ActionResult<Loginrequest> CheckUser([FromBody] Loginrequest request)
        {
            try
            {
                var response = this._Details.verify(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var responce = new ResponseAPI<Loginrequest>(); responce.Msg = ex.Message;
                return BadRequest(responce);
            }
        }
    }
}
