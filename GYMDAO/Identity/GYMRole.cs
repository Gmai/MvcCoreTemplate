using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.Identity
{
    public class GYMRole : IdentityRole<string>
    {
        public GYMRole() { }
        public GYMRole(string roleName) { Name = roleName; }
    }
}
