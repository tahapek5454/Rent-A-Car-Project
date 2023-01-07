using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
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
        IBrandService _brandService;

        public CarManager(ICarDal carDal, IBrandService brandService)
        {
            _carDal = carDal;
            _brandService = brandService;
        }

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            // kurdugumuz ValidationAspecte CarValidator a gore kurdugumuz sistemler sayesinde ilgili parametreyi de alarak islem yap dedik
            // o da yine interception da kurdgumuz sistemler sayesinde attribute ile validate etti onBefore

            var result = BusinessRules.Run(
                CheckcarsBrandRangeCorrect(car.BrandId)
                , CheckBrandCountForCarAdded());

            if (!result.Succes)
            {
                return result;
            }

            _carDal.Add(car);
            return new SuccessResult(Messages.Added);
            
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.Deleted);
        }

        [SecuredOperation("")]
        public IDataResult<List<Car>> GetAll()
        {
            return new DataSuccessResult<List<Car>>(_carDal.GetAll(), Messages.Listed);
        }

        [SecuredOperation("")]
        public IDataResult<List<Car>> GetByColorId(int id)
        {
            return new DataSuccessResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id), Messages.Listed);
        }

        [SecuredOperation("")]
        public IDataResult<Car> GetById(int id)
        {
            return new DataSuccessResult<Car>(_carDal.Get(c => c.Id == id), Messages.Listed);
        }

        [SecuredOperation("")]
        public IDataResult<List<CarDetailsDTO>> GetCarDetails()
        {
            return new DataSuccessResult<List<CarDetailsDTO>>(_carDal.GetCarDetails(), Messages.Listed);
        }

        [SecuredOperation("")]
        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new DataSuccessResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id), Messages.Listed);
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            try
            {
                _carDal.Update(car);
                return new SuccessResult(Messages.Updated);

            }
            catch (Exception)
            {

                Console.WriteLine("Update de hata");
                return new ErrorResult(Messages.NotUpdated);
            }
            
        }


        private IResult CheckcarsBrandRangeCorrect(int brandId)
        {       
            var brandCount = _carDal.GetAll(c => c.BrandId==brandId).Count;
       
            if (brandCount < 10) return new SuccessResult();

            return new ErrorResult(Messages.carsBrandOutOfRange);
            
        }

        private IResult CheckBrandCountForCarAdded()
        {
            var brandCount = _brandService.GetAll().Data.Count;

            if (brandCount > 30) return new ErrorResult(Messages.ArriveBrandCountLimitToAddedCar);

            return new SuccessResult();
          
        }
    }
}
