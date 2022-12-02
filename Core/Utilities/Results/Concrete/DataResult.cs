using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Concrete
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public T Data { get; }

        public DataResult(T data, bool succes, string message):base(succes, message)
        {
            Data = data;
        }

        public DataResult(T data, bool succes):base(succes)
        {
            Data = data;
        }
    }
}
