using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpPost("AddRental")]
        public IActionResult AddRental(Rental rental)
        {
            var result = _rentalService.Add(rental);
            if (result.Succes)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpDelete("DeleteRental")]
        public IActionResult DeleteRental(Rental rental)
        {
            var result = _rentalService.Delete(rental);
            if (result.Succes)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPost("DeliverRental")]
        public IActionResult DeliverRental(int id)
        {
            var result = _rentalService.Deliver(id);
            if (result.Succes)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet("GetAllRentals")]
        public IActionResult GetAllRentals()
        {
            var result = _rentalService.GetAll();
            if (result.Succes)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet("GetByCarIdRental")]
        public IActionResult GetByCarIdRental(int id)
        {
            var result = _rentalService.GetByCarId(id);
            if (result.Succes)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet("GetByIdRental")]
        public IActionResult GetByIdRental(int id)
        {
            var result = _rentalService.GetById(id);
            if (result.Succes)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPost("UpdateRental")]
        public IActionResult UpdateRental(Rental rental)
        {
            var result = _rentalService.Update(rental);
            if (result.Succes)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
    }
}
