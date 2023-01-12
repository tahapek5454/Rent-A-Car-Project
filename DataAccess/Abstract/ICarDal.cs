using Core.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailsDTO> GetCarDetails();
        List<CarDetailsDTO> GetCarDetailsByBrandId(int brandId);
        List<CarDetailsDTO> GetCarDetailsByColorId(int colorId);
        
    }
}
