using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ObjectMapper.Entities;
using ObjectMapper.Models;

namespace ObjectMapper.Mappers
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            // Entity to Model
            CreateMap<User, UserDto>(MemberList.Destination);

            // Model to Entity
            CreateMap<UserDto, User>(MemberList.Source);
        }
    }
}
