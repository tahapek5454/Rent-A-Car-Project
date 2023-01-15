using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;

        }

        [HttpPost("AddCar")]
        public IActionResult AddCar(Car car)
        {
            var result = _carService.Add(car);

            if (result.Succes)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);  
            }

        }

        [HttpDelete("DeleteCar")]
        public IActionResult DeleteCar(Car car)
        {
            var result = _carService.Delete(car);

            if (result.Succes)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }

        }

        [HttpGet("GetAllCar")]
        public IActionResult GetAllCar()
        {
            var result = _carService.GetAll();

            if (result.Succes)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }

        }

        [HttpGet("GetByColorIdCar")]
        public IActionResult GetByColorIdCar(int id)
        {
            var result = _carService.GetByColorId(id);

            if (result.Succes)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }

        }

        [HttpGet("GetByIdCar")]
        public IActionResult GetByIdCar(int id)
        {
            var result = _carService.GetById(id);

            if (result.Succes)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }

        }

        [HttpGet("GetCarDetails")]
        public IActionResult GetCarDetails()
        {
            var result = _carService.GetCarDetails();

            if (result.Succes)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }

        }

        [HttpGet("GetCarDetailsByBrandId")]
        public IActionResult GetCarDetailsByBrandId(int id)
        {
            var result = _carService.GetCarDetailsByBrandId(id);

            if(result.Succes) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("GetCarDetailsByColorId")]
        public IActionResult GetCarDetailsByColorId(int id)
        {
            var result = _carService.GetCarDetailsByColorId(id);

            if (result.Succes) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("GetCarsByBrandId")]
        public IActionResult GetCarsByBrandId(int id)
        {
            var result = _carService.GetCarsByBrandId(id);

            if (result.Succes)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }

        }

        [HttpPost("UpdateCar")]
        public IActionResult UpdateCar(Car car)
        {
            var result = _carService.Update(car);

            if (result.Succes)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }

        }

    }
}
