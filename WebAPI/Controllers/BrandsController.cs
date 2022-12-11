using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpPost("AddBrand")]
        public IActionResult AddBrand(Brand brand)
        {
            var result = _brandService.Add(brand);

            if (result.Succes)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpDelete("DeleteBrand")]
        public IActionResult DeleteBrand(Brand brand)
        {
            var result = _brandService.Delete(brand);
            if (result.Succes)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet("GetAllBrands")]
        public IActionResult GetAllBrands()
        {
            var result = _brandService.GetAll();
            if (result.Succes)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet("GetByIdBrand")]
        public IActionResult GetByIdBrand(int id)
        {
            var result = _brandService.GetById(id);
            if (result.Succes)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPost("UpdateBrand")]
        public IActionResult UpdateBrand(Brand brand)
        {
            var result = _brandService.Update(brand);
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
