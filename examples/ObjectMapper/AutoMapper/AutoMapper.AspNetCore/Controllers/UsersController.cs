using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.AspNetCore.Entities;
using AutoMapper.AspNetCore.Mappers;
using AutoMapper.AspNetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoMapper.AspNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // private readonly IMapper _mapper;
        //
        // public UsersController(IMapper mapper)
        // {
        //     _mapper = mapper;
        // }

        [HttpGet]
        public ActionResult<UserDto[]> Get()
        {
            var users = new[]
            {
                new User
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Tom",
                    Sex = UserSex.Man
                },
            };

            // return _mapper.Map<UserDto[]>(users);
            return Mapster.Mapper.Map<UserDto[]>(users);
        }

        [HttpGet("{id}")]
        public ActionResult<UserDto> Get(string id)
        {
            var user = new User
            {
                Id = id,
                Name = "Tom",
                Sex = UserSex.Man
            };

            // return _mapper.Map<UserDto>(user);
            return Mapster.Mapper.Map<UserDto>(user);
        }
    }
}
