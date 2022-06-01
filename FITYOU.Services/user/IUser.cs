using FITYOU.DATA.Models;
using FITYOU.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITYOU.Services.user
{
    public interface IUser
    {
        Task<FitYouResponse> GetAllUser();
        Task<FitYouResponse> ValidateUser(string user,string password);
        Task<FitYouResponse> GetUser(int id);
        Task<FitYouResponse> UpdateUser(int id, Administrator user);
        Task<FitYouResponse> DeleteUser(int id);
        Task<FitYouResponse> AddUser(Administrator user);
    }
}
