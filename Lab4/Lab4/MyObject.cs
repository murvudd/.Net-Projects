using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class MyObject
    {
        //private int _posx;
        //private int _posy;
        public string Name { get; private set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int VelX { get; set; }
        public int VelY { get { return VelY; } set { } }


        public MyObject(string _name)
        {
            Random rnd = new Random();
            PosX = rnd.Next(1, 19);
            PosY = rnd.Next(1, 19);
            Name = _name;
            VelX = 1;
            VelY = 1;
        }


    }
}
