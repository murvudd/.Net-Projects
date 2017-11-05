using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab2.Models
{
    class Muzyka : Multimedia
    {
        public int LiczbaŚcieżek { get; set; }
        public int Długość { get; set; }

        public Muzyka(int ls, int d, string rodzaj, string autorzy, string tytul, int rok) : base(rodzaj, autorzy, tytul, rok)
        {
            this.LiczbaŚcieżek = ls;
            this.Długość = d;
        }
    }
}