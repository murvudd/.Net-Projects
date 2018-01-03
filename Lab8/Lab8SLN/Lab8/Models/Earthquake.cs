using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.Models
{
    class Earthquake
    {
        public int ID { get; set; }
        public int Rok { get; set; }
        public decimal Siła { get; set; }
        public string Kraj { get; set; }
        public string Miejsce { get; set; }


        public Earthquake()
        {

        }
    }
}
