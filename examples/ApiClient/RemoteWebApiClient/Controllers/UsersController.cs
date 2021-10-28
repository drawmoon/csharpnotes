using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RemoteWebApiClient.Services;

namespace RemoteWebApiClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserApi _userApi;

        public UsersController(IUserApi userApi)
        {
            _userApi = userApi;
        }

        [HttpGet]
        public async Task<ActionResult<string[]>> GetAll()
        {
            return await _userApi.GetAllUser();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<string>> Get([FromRoute] int id)
        {
            return await _userApi.GetUser(id);
        }

        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] string user)
        {
            return await _userApi.AddUser(user);
        }

        [HttpPut]
        public async Task<ActionResult<string>> Put([FromBody] string user)
        {
            return await _userApi.UpdateUser(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _userApi.DeleteUser(id);
            return NoContent();
        }
    }
}