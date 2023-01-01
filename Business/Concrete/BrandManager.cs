using Business.Abstract;
using Business.Constract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);

            return new SuccessResult(Messages.Added);
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);

            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new DataSuccessResult<List<Brand>>(_brandDal.GetAll(), Messages.Listed);
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new DataSuccessResult<Brand>(_brandDal.Get(b => b.Id == id), Messages.Listed);
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);

            return new SuccessResult(Messages.Updated);
        }
    }
}
