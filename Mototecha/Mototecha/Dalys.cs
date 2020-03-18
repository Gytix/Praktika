using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mototecha
{
    class Dalys : IComparable<Dalys>
    {
        public string pavadinimas { get; set; }
        public float kaina { get; set; }
        public string tinkamumas { get; set; }

        public int CompareTo(Dalys other) //NMList.Sort() metodui, pagal gamintoja
        {
            int surikiuotas;
            surikiuotas = string.CompareOrdinal(this.pavadinimas, other.pavadinimas);

            return surikiuotas;
        }
    }
}