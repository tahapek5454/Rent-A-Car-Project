using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Concrete
{
    public class DataErrorResult<T>: DataResult<T>
    {
        public DataErrorResult(T data, string message):base(data, false, message)
        {
            
        }
        public DataErrorResult(T data):base(data, false)
        {

        }
        public DataErrorResult(string message):base(default, false, message)
        {

        }
        public DataErrorResult():base(default, false)
        {

        }
    }
}
