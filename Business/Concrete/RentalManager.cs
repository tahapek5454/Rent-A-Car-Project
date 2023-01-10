using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constract;
using Core.Aspects.Autofac.Authentication;
using Core.Aspects.Autofac.Transaction;
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
    //[AuthenticationAspect]
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [TransactionScopeAspect]
        public IResult Add(Rental rental)
        {
            //?
            var selectedCarId = rental.CarId;
            var selectedCarRentals = this.GetByCarId(selectedCarId).Data;
            rental.RentDate = DateTime.Now;

            if (selectedCarRentals == null)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.Added);
            }
            foreach (var item in selectedCarRentals)
            {
                if (item.ReturnDate == null) return new ErrorResult(Messages.Full);

            }


            _rentalDal.Add(rental);
            return new SuccessResult(Messages.Added);
        }

        [TransactionScopeAspect]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.Deleted);
        }

        [TransactionScopeAspect]
        public IResult Deliver(int carId)
        {
           var allCarRental = _rentalDal.GetAll(r => r.CarId == carId);
            
            if (allCarRental == null) return new ErrorResult(Messages.NotDelivered);

            foreach (var item in allCarRental)
            {
                if (item.ReturnDate == null)
                {
                    Rental rental = new Rental();
                    rental.CarId = carId;
                    rental.ReturnDate = DateTime.Now;
                    rental.RentDate = item.RentDate;
                    rental.Id = item.Id;
                    rental.CustomerId = item.CustomerId;

                    var result = this.Update(rental);

                    if (!result.Succes) return new ErrorResult(Messages.NotDelivered);

                    break;
                }
            }

            return new SuccessResult(Messages.Delivered);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new DataSuccessResult<List<Rental>>(_rentalDal.GetAll(), Messages.Listed);
        }

        public IDataResult<List<Rental>> GetByCarId(int id)
        {
            var result = _rentalDal.GetAll(r => r.CarId == id);
            if (result == null) return new DataErrorResult<List<Rental>>(Messages.NotListed);

            return new DataSuccessResult<List<Rental>>(result, Messages.Listed);
        }

        public IDataResult<Rental> GetById(int id)
        {
            var result = _rentalDal.Get(r => r.Id == id);

            if (result == null) return new DataErrorResult<Rental>(Messages.NotListed);

            return new DataSuccessResult<Rental>(result, Messages.Listed);
        }

        public IDataResult<List<RentalDetailsDTO>> GetRentalDetails()
        {
            return new DataSuccessResult<List<RentalDetailsDTO>>(_rentalDal.GetRentalDetails(), Messages.Listed);
        }

        [TransactionScopeAspect]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.Listed);
        }
    }
}
