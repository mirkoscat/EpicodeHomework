using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitoSpedizioni.Models.Entities;

namespace SitoSpedizioni.Models
{
    public class AggiornamentoSpedizioneViewModel
    {
        public IEnumerable<AggiornamentoSpedizione> Spedizioni { get; set; } = new List<AggiornamentoSpedizione>();
    }
}