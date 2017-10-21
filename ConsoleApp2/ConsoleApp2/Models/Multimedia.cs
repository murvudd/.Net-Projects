using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab2.Models
{
    class Multimedia : Publikacja
    {
        public string Rodzaj { get; set; }
        public Multimedia(string rodzaj, string autorzy, string tytul, int rok) :base(autorzy, tytul, rok)
        {
            this.Rodzaj = rodzaj;
        }
        
    }
}
