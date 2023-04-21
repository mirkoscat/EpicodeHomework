using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitoSpedizioni.Models
{
    public class AnagrafeViewModel
    {
        public IEnumerable<Anagrafe> Anagrafe { get; set; }= new List<Anagrafe>();
    }
}