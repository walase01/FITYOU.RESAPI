using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITYOU.Services.Common
{
    public class Error
    {
        public Error(CodeError code, string message)
        {
            Code = code;
            Message = message;
        }

        public CodeError Code { get; set; }
        public string Message { get; set; } 

    }
}
