using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestionecomuniitaliani.Dati
{
    internal class Ripartizioni
    { public int Id { get; set; }
        public string Denominazione { get; set; }
        public override string ToString()
        {
            return $"Ripartizione(ID = {Id}, Denominazione = {Denominazione})";
        }
    }
}
