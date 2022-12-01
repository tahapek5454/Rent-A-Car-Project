﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailsDTO> GetCarDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result =  from c in context.Cars
                              join co in context.Colors
                              on c.ColorId equals co.Id
                              join b in context.Brands
                              on c.BrandId equals b.Id
                              select new CarDetailsDTO
                              {
                                  BrandName = b.Name,
                                  CarName = b.Name,
                                  ColorName = co.Name,
                                  DailyPrice = c.DailyPrice,
                                  Id = c.Id
                              };
                return result.ToList();

            }
        }
    }
}
