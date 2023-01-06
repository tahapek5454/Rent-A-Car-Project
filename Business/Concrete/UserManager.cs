using Business.Abstract;
using Business.Constract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
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
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
                
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {

            var result = BusinessRules.Run(CheckEmailExistsCorrect(user.Email));

            if (!result.Succes) return result;

            _userDal.Add(user);
            return new SuccessResult(Messages.Added);
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new DataSuccessResult<List<User>>(_userDal.GetAll(), Messages.Listed);
        }

        public IDataResult<User> GetByEmail(string email)
        {
            var data = _userDal.Get(u => u.Email == email);
            if(data == null)
            {
                return new DataErrorResult<User>();
            }
            return new DataSuccessResult<User>(data);
        }

        public IDataResult<User> GetById(int id)
        {
            return new DataSuccessResult<User>(_userDal.Get(u => u.Id == id), Messages.Listed);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new DataSuccessResult<List<OperationClaim>>(_userDal.GetClaims(user), Messages.Listed);
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.Updated);
        }

        private IResult CheckEmailExistsCorrect(string email)
        {
            var data = _userDal.Get(u => u.Email == email);

            if (data == null) return new SuccessResult();

            return new ErrorResult(Messages.EmailAlreadyExists);
        }
    }
}
