using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.API.Models
{
    public class GetUsersRequest
    {
        public List<string> officeIds { get; set; }
    }

    public class UserDto
    {
        public Guid Id { get; set; }

        public string Login { get; set; }

        public Office Office { get; set; }

        public Role[] Roles { get; set; }

    }
}
