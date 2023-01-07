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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            var result = BusinessRules.Run(CheckColorNameExistsCorrect(color.Name));

            if(!result.Succes) return result;


            _colorDal.Add(color);
            return new SuccessResult(Messages.Added);
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.Deleted);
        }

        [SecuredOperation("")]
        public IDataResult<List<Color>> GetAll()
        {
            return new DataSuccessResult<List<Color>>(_colorDal.GetAll(), Messages.Listed);
        }

        [SecuredOperation("")]
        public IDataResult<Color> GetById(int id)
        {
            return new DataSuccessResult<Color>(_colorDal.Get(c => c.Id == id), Messages.Listed);
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color color)
        {

            var result = BusinessRules.Run(CheckColorNameExistsCorrect(color.Name));

            if (!result.Succes) return result;

            _colorDal.Update(color);
            return new SuccessResult(Messages.Updated);
        }

        private IResult CheckColorNameExistsCorrect(string name)
        {
            var data = _colorDal.Get(c => c.Name == name);
            if (data == null) return new SuccessResult();

            return new ErrorResult(Messages.ColorExists);
        }
    }
}
