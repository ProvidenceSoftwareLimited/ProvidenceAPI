using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProvidenceAPI.Models;

namespace ProvidenceAPI.Data
{
    public class ProvidenceAPIContext : DbContext
    {
        public ProvidenceAPIContext (DbContextOptions<ProvidenceAPIContext> options)
            : base(options)
        {
        }

        public DbSet<SecuritiesModel> SecuritiesModel { get; set; }
    }
}
