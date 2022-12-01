using Core.Entities;
using Core.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContex> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContex : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContex context = new TContex())
            {
                var addedCar = context.Entry(entity);
                // aracın referansını database de ara yoksa yeni ekle
                addedCar.State = EntityState.Added;
                // ekleme islemini gerceklestirdik
                context.SaveChanges();

            }
        }

        public void Delete(TEntity entity)
        {
            using (TContex context = new TContex())
            {
                var deletedCar = context.Entry(entity);
                // aracın referansını database de ara 
                deletedCar.State = EntityState.Deleted;
                // silme islemini gerceklestirdik
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContex contex = new TContex())
            {
                return contex.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContex contex = new TContex())
            {
                return filter == null
                ? contex.Set<TEntity>().ToList()
                       : contex.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContex context = new TContex())
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
