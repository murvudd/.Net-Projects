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
        private Random rng = new Random();



        public Pole(int x, int y)
        {
            Xpos = x;
            Ypos = y;
            Dir = rng.Next(8592, 8596);
            // 1 w lewo 2 do góry  3 w prawo  4 w dół
            // 8592     8593        8594        8595
            // 10006 skasowanie obiektu
        }

        public Pole(int dir, int x, int y)
        {
            Xpos = x;
            Ypos = y;
            Dir = dir;
        }

        //public Pole(int i, int j){        }

        public static int Dim(Pole[,] Mapa)
        {
            return Mapa.GetUpperBound(Mapa.Rank - 1) + 1;
        }
    }
}
