using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mototecha
{
    class NaujiM : IComparable<NaujiM>
    {
        public string tipas {get; set;}
        public string gamintojas { get; set; }
        public string modelis { get; set; }
        public string pilnasPavadinimas
        {
            get
            {
                return gamintojas + " " + modelis;
            }
        }
        public int metai { get; set; }
        public int kaina { get; set; }
        public string spalva { get; set; }
        public int kubatura { get; set; }
        public int rida{get; set;}

        public int CompareTo(NaujiM other) //NMList.Sort() metodui, pagal gamintoja
        {
            int surikiuotas;
            surikiuotas = string.CompareOrdinal(this.gamintojas, other.gamintojas);

            return surikiuotas;
        }
        
    }
}
