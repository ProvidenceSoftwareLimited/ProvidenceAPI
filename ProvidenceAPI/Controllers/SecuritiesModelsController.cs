using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.EntityFrameworkCore;
using ProvidenceAPI.Data;
using ProvidenceAPI.Models;
using ProvidenceAPI.Services;
using AutoMapper;

namespace ProvidenceAPI.Controllers
{
    [Route("api/securities")]
    [ApiController]
    public class SecuritiesModelsController : ControllerBase
    {
        private readonly ISecurities _securities;
        public SecuritiesModelsController(ProvidenceAPIContext context)//, ISecurities securities)
        {
        //    _securities = securities;
        }

        // GET: api/SecuritiesModels
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<SecuritiesModel>>> GetSecurities([FromServices] ISecurities _securities)
        {

           var response = await _securities.GetSecurities();
          
           var List = new List<SecuritiesModel>();
            foreach (var item in response)
            {
                List.Add(item);
            }
            return List;

        }

        [HttpPost]
        public async Task<ActionResult<IReadOnlyList<SecuritiesModel>>> GetSecuritiesBodyParameters(
           [FromServices] ISecurities _securities, [FromBody] SecuritiesModel inputModel)
        {

            var response = await _securities.GetSecuritiesBodyParameters(inputModel);

            var List = new List<SecuritiesModel>();
            foreach (var item in response)
            {
                List.Add(item);
            }
            return List;

        }

    }
}
