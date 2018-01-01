using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Atrybut
    {
        public string a { get; set; }
        public string b { get; set; }
        public string c { get; set; }
        public string d { get; set; }
        public string e { get; set; }
        public string f { get; set; }

        public void Metoda()
        {
            string dupa = nameof(this.a);
            Console.WriteLine(dupa);
        }
        //public Atrybut(string _a, string _b, string _c, string _d, string _e, string _f)
        //{
        //    a = _a;
        //    b = _b;
        //    c = _c;
        //    d = _d;
        //    e = _e;
        //    f = _f;
        //}
        public int IleWystąpień(char sw, string x)
        {
            int i = 0;
            switch (sw)
            {
                case 'a':
                    for (int k = 0; k < 8; k++)
                    {
                        if (this.a == x) i++;
                    }
                    break;
                case 'b':
                    for (int k = 0; k < 8; k++)
                    {
                        if (this.b == x) i++;
                    }
                    break;
                case 'c':
                    for (int k = 0; k < 8; k++)
                    {
                        if (this.c == x) i++;
                    }
                    break;
                case 'd':
                    for (int k = 0; k < 8; k++)
                    {
                        if (this.d == x) i++;
                    }
                    break;
                case 'e':
                    for (int k = 0; k < 8; k++)
                    {
                        if (this.e == x) i++;
                    }
                    break;
            }

            return i;
        }
    }
}
