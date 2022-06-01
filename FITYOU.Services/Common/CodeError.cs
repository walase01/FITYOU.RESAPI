using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITYOU.Services.Common
{
    public enum CodeError
    {
        InternalServerError = 500,
        NotFound = 404,
        BadRequest = 400,
        RemoteServerError = 900,
        BadGateway = 502
    }
}
