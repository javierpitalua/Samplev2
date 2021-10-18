using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using App.API.Data;
using App.API.Models;
using App.API.Services;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.API.Controllers
{
    [ApiController]
    [Route("offices")]
    public class OfficeController : ControllerBase
    {
        private readonly IOfficeService officeService;

        public OfficeController(SampleAppContext context, IOfficeService officeService)
        {
            this.officeService = officeService;
        }

        [HttpGet]
        [Route("getOffices")]
        public async Task<Office[]> GetOffices(string searchPattern, CancellationToken ctoken)
        {
            return await this.officeService.GetOffices(searchPattern, ctoken);
        }   
    }
}
