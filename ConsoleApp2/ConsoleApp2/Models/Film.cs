using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab2.Models
{
    class Film : Multimedia
    {
        public int DługośćFilmu { get; set; }

        public Film(int DF, string rodzaj, string autorzy, string tytul, int rok) : base(rodzaj, autorzy, tytul, rok)
        {
            this.DługośćFilmu = DF;
        }
    }
}
