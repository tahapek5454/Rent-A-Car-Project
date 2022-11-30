using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var addedCar = context.Entry(entity);
                // aracın referansını database de ara yoksa yeni ekle
                addedCar.State = EntityState.Added;
                // ekleme islemini gerceklestirdik
                context.SaveChanges();

            }
        }

        public void Delete(Car entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var deletedCar = context.Entry(entity);
                // aracın referansını database de ara 
                deletedCar.State = EntityState.Deleted;
                // silme islemini gerceklestirdik
                context.SaveChanges();

            }

        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (RentACarContext contex = new RentACarContext())
            {
                return contex.Set<Car>().SingleOrDefault(filter);

            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (RentACarContext contex = new RentACarContext())
            {
                return filter == null
                       ? contex.Set<Car>().ToList()
                       : contex.Set<Car>().Where(filter).ToList();

            }
        }

        public void Update(Car entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var updatedCar = context.Entry(entity);
                // aracın referansını database de ara 
                updatedCar.State = EntityState.Modified;
                // guncelleme islemini gerceklestirdik
                context.SaveChanges();

            }
        }
    }
}
