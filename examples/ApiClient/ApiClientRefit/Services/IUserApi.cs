using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiClientRefit.Services
{
    public interface IUserApi
    {
        [Get("/users")]
        Task<string[]> GetAllUser();

        [Get("/users/{id}")]
        Task<string> GetUser(int id);
    }
}
