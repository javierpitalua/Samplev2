using System;
using System.Collections.Generic;
using System.Linq;
using App.API.Data;
using App.API.Models;
using Microsoft.EntityFrameworkCore;

namespace App.API.Services
{
    public interface IUserService
    {
        User[] GetUsers();
    }

    public class UserService
    {
        private readonly SampleAppContext context;

        public UserService(SampleAppContext context)
        {
            this.context = context;
        }

        public User[] GetUsers()
        {
            return context.Users
                .Include(o => o.Office)
                .AsNoTracking() // for perfomance
                .ToArray();
        }

        public UserRole[] GetUserRoles(Guid[] userIds)
        {
            return context.UserRoles
                .Include(o => o.Role)
                .AsNoTracking() // for perfomance
                .ToArray();
        }

        public IEnumerable<Office> GetOffices()
        {
            return context.Offices
                .AsNoTracking() // for perfomance
                .ToArray();
        }
    }
}
