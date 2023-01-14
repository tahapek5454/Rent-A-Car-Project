using Business.Abstract;
using Business.Constract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BankAccountManager : IBankAccountService
    {

        private IBankAccountDal _bankAccountDal;

        public BankAccountManager(IBankAccountDal bankAccountDal)
        {
            _bankAccountDal = bankAccountDal;
        }

        public IResult AddPrice(int price)
        {
            var mainData = _bankAccountDal.Get(b => b.Id == 1);
            mainData.Price += price;

            _bankAccountDal.Update(mainData);
            return new SuccessResult(Messages.Added);
        }

        public IDataResult<BankAccount> GetTotalPrice()
        {
            return new DataSuccessResult<BankAccount>(_bankAccountDal.Get(b => b.Id == 1), Messages.Listed);

        }
    }
}
