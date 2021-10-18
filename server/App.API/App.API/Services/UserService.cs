using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using App.API.Data;
using App.API.Models;
using Microsoft.EntityFrameworkCore;

namespace App.API.Services
{
    public interface IUserService
    {
        Task<UserDto[]> GetUsersByOfficeIds(Guid[] officeIds, CancellationToken ctoken);
    }

    public class UserService : IUserService
    {
        private readonly SampleAppContext context;

        public UserService(SampleAppContext context)
        {
            this.context = context;
        }

        public async Task<UserDto[]> GetUsersByOfficeIds(Guid[] officeIds, CancellationToken ctoken)
        {
            var result =
                (from p in context.Users.Include(x => x.Office)
                    where officeIds.Contains(p.Office.Id)
                    select new UserDto()
                    {
                        Id = p.Id, 
                        Login = p.Login, 
                        Office = p.Office, 
                        Roles = (from q in p.Roles 
                                    select new Role()
                                    {
                                        Id = q.RoleId, 
                                        Name = q.Role.Name
                                    }).ToArray()
                    });

            return await result.ToArrayAsync(ctoken);
        }
    }
}
