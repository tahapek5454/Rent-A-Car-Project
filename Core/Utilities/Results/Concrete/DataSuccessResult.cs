using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Concrete
{
    public class DataSuccessResult<T>:DataResult<T>
    {
        public DataSuccessResult(T data, string message):base(data, true, message)
        {

        }
        public DataSuccessResult(T data):base(data, true)
        {

        }
        public DataSuccessResult(string message):base(default, true, message)
        {

        }
        public DataSuccessResult():base(default, true)
        {

        }
    }
}
