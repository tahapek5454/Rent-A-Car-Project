using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountsController : ControllerBase
    {
        IBankAccountService _accountService;

        public BankAccountsController(IBankAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("AddPrice")]
        public IActionResult AddPrice(int price)
        {
            var data = _accountService.AddPrice(price);
            if(data.Succes) return Ok(data);

            return BadRequest(data.Message);
        }

        [HttpGet("GetTotalPrice")]
        public IActionResult GetTotalPrice()
        {
            var data = _accountService.GetTotalPrice();
            if (data.Succes) return Ok(data);

            return BadRequest(data.Message);

        }
    }
}
