using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car = new Car
            {
                BrandId=3,
                ColorId=2,
                DailyPrice=300,
                Description="Wowwww",
                ModelYear=2010
            };


            // carManager.Add(car);

            foreach (var item in carManager.GetCarDetails())
            {
                Console.WriteLine(item.Id+"/"+item.CarName+"/"+item.ColorName+"/"+item.DailyPrice); 

            }
            
        }
    }
}
