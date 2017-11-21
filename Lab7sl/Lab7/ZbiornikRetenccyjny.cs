using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    class ZbiornikRetenccyjny
    {
        private int _poziomWody { get; set; }
        public int PoziomWody {
            get { return _poziomWody; }
            set { if (value >= 0) _poziomWody = value;}
        }

        public void ZmniejszIlośćWody()
        {
            PoziomWody -= 5;            
        }

    }

}
