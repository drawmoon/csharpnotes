using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ApiClientRefit.Services;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace ApiClientRefit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserApi _userApi;

        public UsersController(IHttpClientFactory httpClientFactory)
        {
            var client = httpClientFactory.CreateClient("user");
            _userApi = RestService.For<IUserApi>(client);
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
    }
}
