﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Concrete
{
    public class ErrorResult:Result
    {
        public ErrorResult():base(false)
        {

        }
        public ErrorResult(string message):base(false, message)
        {

        }
    }
}
