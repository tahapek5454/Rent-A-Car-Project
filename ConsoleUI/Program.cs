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
            // CarTest();

            //RentalManager rentalManager = new RentalManager(new EfRentalDal());

            //Rental rental = new Rental { CarId = 3, CustomerId = 1, RentDate = DateTime.Now };

            //var result = rentalManager.Add(rental);

            //Console.WriteLine(result.Message);



           








        }

        //private static void CarTest()
        //{
        //    //CarManager carManager = new CarManager(new EfCarDal(),);
        //    Car car = new Car
        //    {
        //        BrandId = 3,
        //        ColorId = 2,
        //        DailyPrice = 300,
        //        Description = "Wowwww",
        //        ModelYear = 2010
        //    };


        //    // carManager.Add(car);

        //    //foreach (var item in carManager.GetAll().Data)
        //    //{
        //    //    Console.WriteLine(item.Id);

        //    //}

        //    var result = carManager.GetCarDetails();

        //    if (result.Succes)
        //    {
        //        Console.WriteLine(result.Message);
        //        foreach (var item in result.Data)
        //        {

        //            Console.WriteLine(item.Id + "/" + item.CarName + "/" + item.ColorName + "/" + item.DailyPrice);

        //        }

        //    }
        //    else
        //    {
        //        Console.WriteLine(result.Succes);
        //        Console.WriteLine(result.Message);
        //    }
        //}
    }
}
