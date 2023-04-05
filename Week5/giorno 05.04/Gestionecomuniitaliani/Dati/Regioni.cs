using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestionecomuniitaliani.Dati
{
    internal class Regioni
    {
        public int Id { get; set; }
        public string Denominazione { get; set; }
        //chiavi esterne= oggetto che rappresenta riga tab ripartizioni dentro tab regioni
        public Ripartizioni Ripartizione { get; set; }

        public override string ToString()
        {
            return $"Regione(ID = {Id}, Denominazione = {Denominazione}, Ripartizione = {Ripartizione})";
        }
    }
}
