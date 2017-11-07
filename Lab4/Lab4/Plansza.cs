using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Plansza
    {

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
    }
}
