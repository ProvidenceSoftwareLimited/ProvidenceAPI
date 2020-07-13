using Microsoft.AspNetCore.Mvc;
using ProvidenceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvidenceAPI.Services
{
  public interface ISecurities
    {
     public Task<IReadOnlyList<SecuritiesModel>> GetSecurities();

     public Task<IReadOnlyList<SecuritiesModel>> GetSecuritiesBodyParameters(SecuritiesModel securities);
    }
}
