using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using works.Models;
using works.Services.Contract;
using works.Utilities;

namespace works.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly Iwork _Customer;
        public CustomerController(Iwork Customer)
        {
            _Customer = Customer;
        }
        [HttpPost]
        public IActionResult AddNewData(CustomerDetail employee)
        {
            ResponseAPI<CustomerDetail> response = new ResponseAPI<CustomerDetail>();
            try
            {
                CustomerDetail newDetail = _Customer.AddToList(employee);
                response = new ResponseAPI<CustomerDetail> { Status = true, Msg = "Added", Value = newDetail };
                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                response = new ResponseAPI<CustomerDetail> { Status = false };
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
    }
}
