using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace Lab4
{
    class Obkt
    {
        //private int _posx;
        //private int _posy;
        public string Name { get; set; }
        public int PosX { get; set; }
        
        public int PosY { get; set; }
        public int VelX { get; set; }
        public int VelY { get; set; }

        public Obkt(string _name)
        {
            Random rnd = new Random();
            this.PosX = rnd.Next(1, 19);
            this.PosY = rnd.Next(1, 19);
            this.Name = _name;
        }

        
    }
}
