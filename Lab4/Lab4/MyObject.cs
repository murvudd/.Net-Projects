using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class MyObject : Pole
    {
        private int _velx;
        private int _vely;
        private int _posx;
        private int _posy;
        public string Name { get; private set; }
        public int PosX {
            get { return _posx; }

            set {
                if(value>=0 && value <= 19)
                {
                    _posx = value;
                }
            }
        }


        public int PosY
        {
            get { return _posy; }

            set
            {
                if (value >= 0 && value <= 19)
                {
                    _posy = value;
                }
            }
        }

        public int VelX
        {
            get { return this._velx; }
            set
            {
                if (Math.Abs(VelX + value) <= 1) //   || (VelX + value) == 0)
                {
                    _velx = value;
                }
                else
                {
                    ;
                }
            }
        }
        public int VelY
        {
            get { return this._vely; }
            set
            {
                if (Math.Abs(VelY + value) <= 1) //   || (VelY + value) == 0)
                {
                    _vely = value;
                }
                else
                {
                    ;
                }
            }
        }


        public MyObject(string _name, int n0, int n1)
        {
            Random rnd = new Random();
            PosX = rnd.Next(1, n1);
            PosY = rnd.Next(1, n0);
            Name = _name;
            VelX = rnd.Next(0, 2) * 2 - 1;
            VelY = rnd.Next(0, 2) * 2 - 1;

        }

        public void ChangeVel(Pole[,] a)
        { 
            switch (a[PosY, PosX].Dir)
            {
                case 8592:
                    VelX = -1;
                    break;

                case 8593:
                    VelY = -1;
                    break;

                case 8594:
                    VelX = 1;
                    break;

                case 8595:
                    VelY = 1;
                    //a[j, i].View = (char)8595;
                    break;

                case 10006:
                    //a[j, i].View = (char)10006;
                    break;
            }
            if (((PosX + VelX) >= 0 && (PosX + VelX) <= a.GetUpperBound(1))
                &&
                ((PosY + VelY) >= 0 && (PosY + VelY) <= a.GetUpperBound(0))
                )
            {
                PosX += VelX;
                PosY += VelY;
            }
            //if ((PosX + VelX) >= 0 && (PosX + VelX) <= a.GetUpperBound(1)) PosX += VelX;
            //if ((PosY + VelY) >= 0 && (PosY + VelY) <= a.GetUpperBound(0)) PosY += VelY;
            //a[j, i].View = (char)Convert.ToInt16(Name);

            }


        //public void ChangeView(Pole a)
        //{
        //    a.View = (char)Convert.ToInt16(Name);
        //}

        public void DrawPole(Pole [,] a)
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(PosX, PosY);
            Console.Write((char)a[PosY, PosY].Dir);
        }

        public void DrawObjct(Pole[,] a) 
        {
            if (PosX !=0 && PosX!= a.GetUpperBound(1) && PosY !=0 && PosY != a.GetUpperBound(0))
            {
                Console.CursorVisible = false;
                Console.SetCursorPosition(PosX, PosY);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(Name);
                Console.ResetColor();
            }
        }

    }
}
