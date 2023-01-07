using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
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

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            var result = BusinessRules.Run(CheckBrandNameExistsCorrect(brand.Name));

            if (!result.Succes)
            {
                return result;
            }

            _brandDal.Add(brand);

            return new SuccessResult(Messages.Added);
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);

            return new SuccessResult(Messages.Deleted);
        }

        [SecuredOperation("")]
        public IDataResult<List<Brand>> GetAll()
        {
            return new DataSuccessResult<List<Brand>>(_brandDal.GetAll(), Messages.Listed);
        }

        [SecuredOperation("")]
        public IDataResult<Brand> GetById(int id)
        {
            return new DataSuccessResult<Brand>(_brandDal.Get(b => b.Id == id), Messages.Listed);
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Brand brand)
        {

            var result = BusinessRules.Run(CheckBrandNameExistsCorrect(brand.Name));

            if (!result.Succes)
            {
                return result;
            }

            _brandDal.Update(brand);

            return new SuccessResult(Messages.Updated);
        }

        private IResult CheckBrandNameExistsCorrect(string name)
        {
            var data = _brandDal.Get(b => b.Name == name);

            if (data == null) return new SuccessResult();

            return new ErrorResult(Messages.brandNameExist);
        }
    }
}
