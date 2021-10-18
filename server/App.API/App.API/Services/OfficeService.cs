using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using App.API.Data;
using App.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace App.API.Services
{
    public interface IOfficeService
    {
        Task<Office[]> GetOffices(string searchPattern, CancellationToken ctoken);
    }
    public class OfficeService : IOfficeService
    {
        private readonly SampleAppContext context;

        public OfficeService(SampleAppContext context)
        {
            this.context = context;
        }

        public async Task<Office[]> GetOffices(string searchPattern, CancellationToken ctoken)
        {
            if (string.IsNullOrWhiteSpace(searchPattern))
            {
                return await (from p in context.Offices select p).ToArrayAsync(ctoken);
            }

            return await (from p in context.Offices
                where EF.Functions.Like(p.Address, $"%{searchPattern}%")
                select p).ToArrayAsync(ctoken);
        }
    }
}
