using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestionecomuniitaliani.Dati
{
    internal class Province
    {
        public string Sigla { get; set; }
        public string Denominazione { get; set; }
        public Regioni Regione { get; set; }
        public override string ToString()
        {
            return $"Provincia Sigla= {Sigla}, Denominazione = {Denominazione}";
        }
    }
}
