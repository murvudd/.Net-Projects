using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    class Email : IDokument<Email>
    {
        public int Priorytet {get; set;}

       public void Podnieś(Email email)
        {
            this.Priorytet += 10;

        }
    }
}
