using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using App.API.Models;
using App.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        [Route("getUsers")]
        public async Task<IEnumerable<UserDto>> GetUsers([FromBody] GetUsersRequest request, CancellationToken ctoken)
        {
            var ids = request.officeIds == null ? new Guid[]{} :
                (from office in request.officeIds select new Guid(office)).ToArray();
            return await this.userService.GetUsersByOfficeIds(ids, ctoken);
        }
    }
}
