using FITYOU.DATA.Models;
using FITYOU.Services.user;
using Microsoft.AspNetCore.Mvc;

namespace FITYOU.RestApi.Controllers
{
    [ApiController]
    [Route("api/Usarios")]
    public class UserController : Controller
    {
        private readonly IUser service;

        public UserController(IUser service)
        {
            this.service = service;
        }

        [Route("GetAllUser")]
        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            var result = await this.service.GetAllUser();
            return Ok(result);
        }
        [Route("ValidateUser/{user}/{password}")]
        [HttpGet]
        public async Task<IActionResult> ValidateUser(string user, string password)
        {
            var result = await this.service.ValidateUser(user, password);
            return Ok(result);
        }
        [Route("GetUserById/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetUserById(int id)
        {
            var result = await this.service.GetUser(id);
            return Ok(result);
        }
        [Route("UpdateUser/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateUser(int id,[FromBody] Administrator user)
        {
            var result = await this.service.UpdateUser(id, user);
            return Ok(result);
        }
        [Route("AddUser")]
        [HttpPost]
        public async Task<IActionResult> AddUser(Administrator user)
        {
            var result = await service.AddUser(user);
            return Ok(result);
        }
        [Route("DeleteUser")]
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await service.DeleteUser(id);
            return Ok(result);
        }
    }
}
