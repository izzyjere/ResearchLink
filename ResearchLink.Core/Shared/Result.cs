﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchLink.Core.Shared
{
    public record Result(bool Succeded,string Message)
    {
        public static Result Success(string message = "")
        {
            return new Result(true, message);
        }
        public static Result Failure(string messsage)
        {
            return new Result(false, messsage);
        }
    }
}
