using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab2.Models
{
    class Tygodnik : Czasopismo
    {
        public int Numer { get; set; }

        public Tygodnik(int numer, string autor, string tytuł, int rok) : base(numer, autor, tytuł, rok)
        {
            this.Numer = numer;

        }
    }
}
