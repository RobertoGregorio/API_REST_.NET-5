using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDD.Domain.Entities;

namespace WebApiDDD.Services
{
    public interface ITokenService
    {
        string CreateNewJwtToken(string key, string issuer,string audience, UserModel user);
    }
}