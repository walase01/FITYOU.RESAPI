using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITYOU.Services.Common
{
    public class FitYouResponse
    {
        public bool Succeeded
        {
            get
            {
                return !Errors.Any();
            }
        }
        public string? Message { get; set; }
        public List<Error> Errors { get; set; } = new List<Error>();
    }
    public class FitYouResponse<T> : FitYouResponse where T : class
    {
        public T? Value { get; set; }
    }
}
