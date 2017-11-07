using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab4
{
    class Plansza
    {
        static public int[,] Map { get; set; }
        
        static Plansza()
        {

        }

        public static void Populate()
        {
            Plansza _mapa = new Plansza();
            
            Random rnd = new Random();
            try
            {
                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        Map[i, j] = rnd.Next(1, 4);


                    }
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        static void Move(Obkt o, Plansza[,] m,int i, int j)
        {
            try
            {
                switch (int.Parse(m[i, j].ToString()))// 1 w lewo 2 w dół  3 w prawo  4 do góry
                {
                    case 1:
                        o.VelX = -1;
                        break;

                    case 2:
                        o.VelY = 1;
                        break;

                    case 3:
                        o.VelX = 1;
                        break;

                    case 4:
                        o.VelY = -1;
                        break;

                }
            }
            catch ( Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
        
        static void DrawLine(int w, string ends, string mids)
        {
            Console.Write(ends);
            for (int i = 1; i < w - 1; ++i)
                Console.Write(mids);
            Console.WriteLine(ends);
        }

        public static void DrawBox(int w, int h)
        {
            DrawLine(w, "* ", "* ");
            for (int i = 1; i < h - 1; ++i)
            {
                
                DrawLine(w, "* ", "  ");
            }
            
            DrawLine(w, "* ", "* ");
            Console.WriteLine();
        }

        public static void DrawMap()
        {
            Plansza.Populate();
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j<20; i++)
                {
                    Console.Write(Map[i, j]);
                }
            }
            
        }
    }
}
