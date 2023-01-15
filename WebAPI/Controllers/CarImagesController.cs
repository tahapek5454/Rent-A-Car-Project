using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;
        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }
        [HttpPost("AddCarImage")]
        public IActionResult AddCarImage([FromForm] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImageService.Add(file, carImage);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("DeleteCarImage")]
        public IActionResult DeleteCarImage(CarImage carImage)
        {
            var carDeleteImage = _carImageService.GetByImageId(carImage.Id).Data;
            var result = _carImageService.Delete(carDeleteImage);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("UpdateCarImage")]
        public IActionResult UpdateCarImage([FromForm] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImageService.Update(file, carImage);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetAllCarImages")]
        public IActionResult GetAllCarImages()
        {
            var result = _carImageService.GetAll();
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetByCarIdCarImage")]
        public IActionResult GetByCarIdCarImage(CarImage carImage)
        {
            var result = _carImageService.GetByCarId(carImage.CarId);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetByIdCarImage")]
        public IActionResult GetByIdCarImage(CarImage carImage)
        {
            var result = _carImageService.GetByImageId(carImage.Id);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
