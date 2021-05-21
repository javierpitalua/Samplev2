using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.API.Models
{
    public class Office
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
    }

    public class UserRole
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid RoleId { get; set; }
        public Role Role { get; set; }
    }

    public class Role
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class User
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public Office Office { get; set; }
        public List<UserRole> Roles { get; set; }
    }
}
