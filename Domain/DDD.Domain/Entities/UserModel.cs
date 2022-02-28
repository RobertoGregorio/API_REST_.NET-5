using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDD.Domain.Base;

namespace DDD.Domain.Entities
{
    public class UserModel 
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}