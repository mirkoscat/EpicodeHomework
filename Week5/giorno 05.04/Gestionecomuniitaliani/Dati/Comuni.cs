using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestionecomuniitaliani.Dati
{
    internal class Comuni
    {
        public int Id { get; set; }
        public string Denominazione { get; set; }
        public string SiglaProvincia { get; set; }
        public bool Capoluogo { get; set; }
        public string Catastale { get; set; }
        public Province Provincia { get; set; }
        public override string ToString()
        {
            return $"Comune(ID = {Id}, Denominazione = {Denominazione}, SiglaProvincia = {SiglaProvincia}, Capoluogo = {Capoluogo}, Catastale = {Catastale}, Provincia = {Provincia})";
        }
    }
}
