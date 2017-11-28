using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    class Pismo :IDokument<Pismo>
    {
        public int priorytet { get; set; }

        public void Podnieś(Pismo pismo)
        {
            this.priorytet += 1;
        }
    }
}
