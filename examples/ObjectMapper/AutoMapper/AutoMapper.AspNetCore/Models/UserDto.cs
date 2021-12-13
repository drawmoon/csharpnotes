using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.AspNetCore.Entities;

namespace AutoMapper.AspNetCore.Models
{
    public class UserDto
    {
        public string? Id { get; set; }

        public string? Name { get; set; }

        public UserSex Sex { get; set; }
    }
}
