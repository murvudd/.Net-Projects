using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    class Szpital
    {
        public bool IsGeneratorOn { get; set; }
        public void WłączZasilanieAwaryjne()
        {
            IsGeneratorOn = true;
        }
    }
}
