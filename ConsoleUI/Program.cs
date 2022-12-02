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

            var result = carManager.GetCarDetails();

            if (result.Succes)
            {
                Console.WriteLine(result.Message);
                foreach (var item in result.Data)
                {
                    
                    Console.WriteLine(item.Id + "/" + item.CarName + "/" + item.ColorName + "/" + item.DailyPrice);

                }

            }
            else
            {
                Console.WriteLine(result.Succes);
                Console.WriteLine(result.Message);
            }

            
            
        }
    }
}
