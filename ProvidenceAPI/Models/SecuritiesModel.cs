using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProvidenceAPI.Models
{
    public class SecuritiesModel
    {
       [Key]
        public string Symbol {get; set;}
        public string Description { get; set; }
        public string SECURITY_TYP { get; set; }
        public string MARKET_SECTOR_DES { get; set; }
        public string NAME { get; set; }
    }
}
