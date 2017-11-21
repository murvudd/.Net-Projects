using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    class Elektrownia
    {
        public bool TrybAwaryjny { get; set; }


        public void WłączZasilanieAwaryjne()
        {
            TrybAwaryjny = true;
        }
    }
}
