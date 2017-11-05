using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab2.Models
{
    class Książka : Publikacja
    {
        public int LiczbaStron { get; set; }

        public Książka(int LczbStrn, string autorzy, string tytuł, int rok) : base(autorzy, tytuł, rok)
        {
            this.LiczbaStron = LczbStrn;

        }
    }
}