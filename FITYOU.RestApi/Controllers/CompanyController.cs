using FITYOU.Services.Company;
using Microsoft.AspNetCore.Mvc;

namespace FITYOU.RestApi.Controllers
{
    [ApiController]
    [Route("api/Company")]
    public class CompanyController : Controller
    {
        private readonly ICompany service;
        public CompanyController(ICompany service)
        {
            this.service = service;
        }

        [Route("GetAllCompany")]
        [HttpGet]
        public async Task<IActionResult> GetAllCompany()
        {
            var result = await service.GetAllCompany();
            return Ok(result);
        }
    }
}
