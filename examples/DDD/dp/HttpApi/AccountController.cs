using DomainPrimitive.Application.Command;
using DomainPrimitive.Application.Dto;
using DomainPrimitive.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DomainPrimitive.HttpApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Register([FromBody] CreateUserCommand createUserCommand)
        {
            return await accountService.Register(createUserCommand);
        }
    }
}
