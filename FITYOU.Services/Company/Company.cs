using FITYOU.DATA.Contexts;
using FITYOU.Services.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITYOU.Services.Company
{
    public class Company : ICompany
    {
        private readonly FitYouDB2Context context;

        public Company(FitYouDB2Context _context)
        {
            this.context = _context;
        }

        public async Task<FitYouResponse> GetAllCompany()
        {
            var result = new FitYouResponse<List<DATA.Models.Company>>();

            try
            {

                var response = await this.context.Companies.ToListAsync();

                if (response != null)
                {
                    result.Value = response;
                }
                else
                {
                    result.Errors.Add(new Error(CodeError.NotFound, "No se han encontrado compañias"));
                }
                return result;

            }catch (Exception ex)
            {
                result.Errors.Add(new Error(CodeError.BadRequest, ex.Message));
                return result;
            }
        }

        public async Task<FitYouResponse> SearchCompanyById(int id)
        {
            var result = new FitYouResponse<DATA.Models.Company>();

            try
            {

                var response = await this.context.Companies.FindAsync(id);

                if (response != null)
                {
                    result.Value = response;
                }
                else
                {
                    result.Errors.Add(new Error(CodeError.NotFound, "No se han encontrado la compañia"));
                }
                return result;

            }
            catch (Exception ex)
            {
                result.Errors.Add(new Error(CodeError.BadRequest, ex.Message));
                return result;
            }
        }

        public Task<FitYouResponse> UpdateCompany(int id, DATA.Models.Company company)
        {
            throw new NotImplementedException();
        }

        //public Task<FitYouResponse> UpdateCompany(int id, DATA.Models.Company company)
        //{
        //var result = new FitYouResponse<DATA.Models.Company>();

        //try
        //{

        //    var response = await this.context.Companies.FindAsync(id);

        //    if (response != null)
        //    {
        //        result.Value = response;
        //    }
        //    else
        //    {
        //        result.Errors.Add(new Error(CodeError.NotFound, "No se han encontrado la compañia"));
        //    }
        //    return result;

        //}
        //catch (Exception ex)
        //{
        //    result.Errors.Add(new Error(CodeError.BadRequest, ex.Message));
        //    return result;
        //}
        //}

    }
}
