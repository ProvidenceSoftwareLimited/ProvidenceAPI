using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProvidenceAPI.Data;
using ProvidenceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvidenceAPI.Services
{
    public class Securities : ISecurities
    {
      //  private List<SecuritiesModel> _securities;
        private readonly ProvidenceAPIContext _dbContext;

        public Securities(ProvidenceAPIContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IReadOnlyList<SecuritiesModel>> GetSecurities()
        {
            return await _dbContext.SecuritiesModel.FromSqlInterpolated($"dbo.spGetSecurities").ToListAsync(); 
        }

        public async Task<IReadOnlyList<SecuritiesModel>> GetSecuritiesBodyParameters(SecuritiesModel securitiesinput)
        {
            return await _dbContext.SecuritiesModel.FromSqlInterpolated($"dbo.spGetSecurities  {securitiesinput.Symbol}").ToListAsync();
        }
    }
}
