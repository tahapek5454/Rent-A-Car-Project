using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        public bool Succes { get; }

        public string Message { get; }

        public Result(bool succes)
        {
            Succes = succes;

        }
        public Result(bool succes, string message):this(succes)
        {
            Message = message;
        }
    }
}
