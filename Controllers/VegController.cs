using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using works.Models;
using works.Services.Contract;
using works.Utilities;

namespace works.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VegController : ControllerBase
    {
        private readonly Iwork _Veg;
        public VegController(Iwork Veg)
        {
            _Veg = Veg;
        }
        [HttpGet("vegitable")]
        
        public IActionResult GetEmployeeDetails()
        {
            ResponseAPI<List<Vegetable>> response = new ResponseAPI<List<Vegetable>>();
            try
            {
                List<Vegetable> vegtablenew = _Veg.GetAllDetails();
                response = new ResponseAPI<List<Vegetable>> { Value = vegtablenew };
                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                response = new ResponseAPI<List<Vegetable>>();
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

        }
    }
}
