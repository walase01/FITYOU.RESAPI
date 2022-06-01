using FITYOU.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITYOU.Services.Company
{
    public interface ICompany
    {
        Task<FitYouResponse> GetAllCompany();
        Task<FitYouResponse> SearchCompanyById(int id);
        Task<FitYouResponse> UpdateCompany(int id, DATA.Models.Company company);
    }
}
