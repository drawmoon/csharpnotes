using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ObjectMapper.Entities;

namespace ObjectMapper.Models
{
    public class UserDto
    {
        public string? Id { get; set; }

        public string? Name { get; set; }

        public UserSex Sex { get; set; }
    }
}
