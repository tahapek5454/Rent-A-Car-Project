using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;

        }
        public void Add(Car car)
        {
            if (car.Description.Length >2 && car.DailyPrice>0)
            {
                _carDal.Add(car);
                Console.WriteLine("Araba Basarili Bir Sekilde Eklendi");
            }
            else
            {
                Console.WriteLine("Araba Kosullarimizi Karsilamiyor Tekrar Deneyiniz.");
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetByColorId(int id)
        {
            return _carDal.GetAll(c=> c.ColorId == id);
        }

        public Car GetById(int id)
        {
            return _carDal.Get(c => c.Id == id);
        }

        public List<CarDetailsDTO> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);    
        }
    }
}
