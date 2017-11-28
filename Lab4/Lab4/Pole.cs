using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Pole
    {
        public int Dir { get; private set; }
        public int Xpos { get; private set; }
        public int Ypos { get; private set; }
        //public char View { get; set; }

        private Random rng = new Random();



        public Pole()
        {

        }
        public Pole(int x, int y)
        {
            Xpos = x;
            Ypos = y;
            Dir = rng.Next(8592, 8596);
            //View = 'X';
            // 1 w lewo 2 do góry  3 w prawo  4 w dół
            // 8592     8593        8594        8595
            // 10006 skasowanie obiektu
        }

        public Pole(int dir, int x, int y)
        {
            Xpos = x;
            Ypos = y;
            Dir = dir;
            //View = 'X';
        }


        
    }
}
