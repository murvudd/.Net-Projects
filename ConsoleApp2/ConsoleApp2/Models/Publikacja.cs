using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab2.Models
{
    class Publikacja
    {
        public int ID { get; private set; }
        public static int GlobalID;
        public string Autorzy { get; set; }
        public string Tytuł { get; set; }
        public int RokWydania { get; set; }

        public Publikacja(string autorzy, string tytuł, int rok)
        {
            this.Autorzy = autorzy;
            this.Tytuł = tytuł;
            this.RokWydania = rok;
            this.ID = Interlocked.Increment(ref GlobalID);
        }
    }
}