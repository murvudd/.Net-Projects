using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    class Lotnisko
    {
        public bool IsClosed { get; set; }
        public void Open() {
            IsClosed = false;
        }
        public void Close()
        {
            IsClosed = true;
        }
    }
    
}
